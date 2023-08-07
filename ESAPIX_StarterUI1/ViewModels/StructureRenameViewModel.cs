using ESAPIX.Interfaces;
using Prism.Mvvm;
using VMS.TPS.Common.Model.API;
using System.Collections.ObjectModel;
using System;
using System.Linq;

namespace ESAPX_StarterUI.ViewModels
{
    public class StructureRenameViewModel : BindableBase
    {
        private IESAPIService _es;
        private ObservableCollection<Structure> _structures;
        private Structure _selectedStructure;
        private ObservableCollection<string> _recommendedNames;
        private string _selectedRecommendedName;

        public ObservableCollection<Structure> Structures
        {
            get { return _structures; }
            set { SetProperty(ref _structures, value); }
        }

        public Structure SelectedStructure
        {
            get { return _selectedStructure; }
            set
            {
                SetProperty(ref _selectedStructure, value);
                _recommendedNames = GetRecommendedNames(_selectedStructure);
            }
        }

        public ObservableCollection<string> RecommendedNames
        {
            get { return _recommendedNames; }
            set { SetProperty(ref _recommendedNames, value); }
        }

        public string SelectedRecommendedName
        {
            get { return _selectedRecommendedName; }
            set { SetProperty(ref _selectedRecommendedName, value); }
        }

        public StructureRenameViewModel(IESAPIService es)
        {
            _es = es;
            _es.Execute(sac =>
            {
                var selectedPlan = sac.PlanSetup; // assuming PlanSetup is the selected plan
                if (selectedPlan != null)
                {
                    Structures = new ObservableCollection<Structure>(selectedPlan.StructureSet.Structures);
                }
            });
        }

        private ObservableCollection<string> GetRecommendedNames(Structure structure)
        {
            // Assuming that you have a way to get recommended names for a structure
            return new ObservableCollection<string>(); // replace with actual logic
        }
    }
}
