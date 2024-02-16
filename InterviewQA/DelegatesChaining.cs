using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualBasic;

namespace InterviewQA
{
    public class DelegatesChaining
    {
        public DelegatesChaining()
        {
            var change = new ChangeDetails()
            {
                Id = 1,
                Name = "Hasan",
                IsValid = true
            };

            var changer = new MakeChanges();
            var changeUtils = new ChangeUtils();

            changer.OnChangeValidated += changeUtils.SaveChangeToList;
            changer.OnChangeValidated += changeUtils.PrioritizeChange;
            changer.OnProcessing += changeUtils.Process;

            var local = "LOCAL VAR";

            Action<ChangeDetails> processCompletedChain = (cd) =>
            {
                System.Console.WriteLine($"Lambda + Local : Do proper work for {cd.Name} {local}");
            };
            processCompletedChain += (cd) =>
            {
                System.Console.WriteLine($"Lambda + Local : Do proper work for {cd.Name} {local}");
            };
            processCompletedChain += (cd) =>
            {
                System.Console.WriteLine($"Lambda + Local : Do proper work for {cd.Name} {local}");
            };
            changer.Process(change, processCompletedChain);
        }
    }

    public class ChangeDetails
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public bool IsValid { get; set; }
    }

    public class ChangeUtils
    {
        public void SaveChangeToList()
        {
            Console.WriteLine("Change saved to list");
        }

        public void PrioritizeChange()
        {
            Console.WriteLine("Change Prioritized");
        }

        public void DoPaperWork(ChangeDetails changeDetails)
        {
            Console.WriteLine("Do paper work for {0}", changeDetails.Name);
        }

        public void CheckPaperWork(ChangeDetails changeDetails)
        {
            Console.WriteLine("Check paper work for {0}", changeDetails.Name);
        }

        public void CleanUpAfterPaperWork(ChangeDetails changeDetails)
        {
            Console.WriteLine("Clean up after paper work for {0}", changeDetails.Name);
        }

        public bool Process(ChangeDetails changeDetails)
        {
            return changeDetails.IsValid;
        }
    }

    public class MakeChanges
    {
        public Action OnChangeValidated { get; set; }

        public Func<ChangeDetails, bool> OnProcessing { get; set; }

        private bool Validate(ChangeDetails changeDetails)
        {
            try
            {
                ArgumentNullException.ThrowIfNull(changeDetails);
            }
            catch
            {
                return false;
            }

            OnChangeValidated?.Invoke();
            return true;
        }

        public void Process(ChangeDetails changeDetails,
                            Action<ChangeDetails>? processCompleted = default)
        {
            if (!Validate(changeDetails))
            {
                return;
            }

            if (OnProcessing?.Invoke(changeDetails) == true)
            {
                processCompleted?.Invoke(changeDetails);
            }
        }
    }
}