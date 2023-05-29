using SBMS.Models.Employees;
using SBMS.Repositories;
using SBMS.Repositories.EmployeesRepo;
using SBMS.Views.Employees;
using SBMS.Views.Purchases;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SBMS.Presenters.EmployeesPres
{
    class JobsVPres
    {
        IJobsV jobsV;
        private bool IsEdit = false;
        private JobM SelectedJob;
        /// <summary>
        /// 
        /// </summary>
        private static JobsVPres instance;
        public static JobsVPres GetInstance()
        {
            if (instance == null) instance = new JobsVPres();
            return instance;
        }
        public static void Dispose()
        {
            instance = null;
        }
        private JobsVPres()
        {
            this.jobsV = EmployeesHV.GetInstance();
            OnInitAsync();
        }

        private async Task OnInitAsync()
        {
            await LoadCategoriesAsync();
            this.jobsV.ShowAddJobForm += delegate { ShowAddCustCategoryForm(); };
            this.jobsV.ShowEditJobForm += delegate { ShowEditCustCategoryForm(); };
            this.jobsV.OnAEJobSave += delegate { OnAEJobSave(); };
            this.jobsV.OnAEJobCancel += delegate { OnAEJobCancel(); };
            this.jobsV.DeleteSelectedJob += async delegate { await OnDeleteSelectedJobAsync(); };
            this.jobsV.OnSelectJob += delegate { OnSelectJob(); };
            this.jobsV.OnDisposed += delegate { Dispose(); };
            this.ResetAll();
        }

        private void ShowAddCustCategoryForm()
        {
            this.IsEdit = false;
            this.jobsV.IsAEJobTitleFormVisable = true;
        }

        private void ShowEditCustCategoryForm()
        {
            if (this.SelectedJob == null)
            {
                this.jobsV.ShowMsgBox("Must Select Job To Edit From List", "Error:", false);
                return;
            }
            this.IsEdit = true;
            this.SetAllFields(this.SelectedJob);
            this.jobsV.IsAEJobTitleFormVisable = true;
        }

        private void SetAllFields(JobM jobM)
        {
            this.jobsV.JobName = jobM.Name;
            this.jobsV.JobDescription = jobM.Description;
        }

        private void OnAEJobSave()
        {
            if (IsEdit)
            {
                this.EditJobAsync();
            }
            else
            {
                this.AddJobAsync();
            }
        }

        private async Task AddJobAsync()
        {
            if (this.jobsV.ShowMsgBox("Are You Sure?\nYou Want To Save", "Confirm:", true))
            {

                RepoResultM res = await JobsRepo.AddJobAsync(SetJobM(null));
                if (res.IsSucess)
                {
                    this.LoadCategoriesAsync();
                    this.ResetAll();
                    this.jobsV.ShowMsgBox("Save Sucessful", "Sucess:", false);
                }
                else
                {
                    this.jobsV.ShowMsgBox(res.ErrorMsg, "Error:", false);
                }
            }
        }

        private async Task EditJobAsync()
        {
            if (this.jobsV.ShowMsgBox("Are You Sure?\nYou Want To Save Changes", "Confirm:", true))
            {
                RepoResultM res = await JobsRepo.UpdateJobAsync(SetJobM(this.SelectedJob));
                if (res.IsSucess)
                {
                    LoadCategoriesAsync();
                    ResetAll();
                    this.jobsV.ShowMsgBox("Save Changes Sucessful", "Sucess:", false);

                }
                else
                {

                    this.jobsV.ShowMsgBox(res.ErrorMsg, "Error:", false);
                }
            }
        }

        private JobM SetJobM(JobM jobM)
        {
            if (jobM == null) jobM = new JobM();
            jobM.Name = this.jobsV.JobName;
            jobM.Description = this.jobsV.JobDescription;
            return jobM;
        }

        private void OnAEJobCancel()
        {
            this.ResetAll();
        }

        private void ResetAll()
        {
            this.jobsV.DGVJobs.ClearSelection();
            this.SelectedJob = null;
            this.jobsV.JobName = null;
            this.jobsV.JobDescription = null;
            this.jobsV.IsAEJobTitleFormVisable = false;
            this.IsEdit = false;
        }

        private async Task OnDeleteSelectedJobAsync()
        {
            if (this.SelectedJob == null)
            {
                this.jobsV.ShowMsgBox("Must Select Job To Delete From List", "Error:", false);
                return;
            }
            if (this.jobsV.ShowMsgBox("Are You Sure, You Want To Delete It", "Confirm:", true))
            {
                RepoResultM res = await JobsRepo.DeleteJobAsync(this.SelectedJob.Id);
                if (res.IsSucess)
                {
                    this.LoadCategoriesAsync();
                    this.ResetAll();
                }
                else
                {
                    this.jobsV.ShowMsgBox(res.ErrorMsg, "Error:", false);
                }
            }
        }

        private void OnSelectJob()
        {
            if (this.jobsV.DGVJobs.SelectedRows.Count == 1)
                this.SelectedJob = (JobM)this.jobsV.DGVJobs.SelectedRows[0].DataBoundItem;
        }

        private async Task LoadCategoriesAsync()
        {
            RepoResultM res = await JobsRepo.GetJobsAsync();
            this.jobsV.DGVJobs.DataSource = null;
            if (res.IsSucess)
            {
                List<JobM> jobList = new List<JobM>();
                for (int i = 0; i < res.ResData.Count; i++)
                {
                    jobList.Add((JobM)res.ResData[i]);
                }

                if (jobList.Count > 0)
                {
                    this.jobsV.DGVJobs.DataSource = jobList;
                    this.jobsV.DGVJobs.ClearSelection();
                }
            }
            else
            {
                if (res.ErrorMsg == "No Result")
                {
                    this.jobsV.ShowMsgBox("The Job List Is Empty", "Note:", false);
                    return;
                }
                this.jobsV.ShowMsgBox(res.ErrorMsg, "Error:", false);
            }
        }
    }
}
