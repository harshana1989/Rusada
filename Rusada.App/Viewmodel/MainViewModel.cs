using Newtonsoft.Json;
using Rusada.App.Base.ViewModel;
using Rusada.App.Helpers;
using Rusada.Common.CommenModel;
using Rusada.Common.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Rusada.App.Viewmodel
{
    public class MainViewModel : ViemModelBase
    {
        private readonly SpotterEntity _Spotter = new SpotterEntity();
        public MainViewModel()
        {
            MakeTypeList = new List<MakeEntity>();
            ModelTypeList = new List<ModelEntity>();
            SpotterTypeList = new List<SpotterEntity>();
            SerchTypeList = new List<SerchTypeEntity>();

            SaveCommand = new RelayCommand(SaveMethod);
            NewCommand = new RelayCommand(NewMethod);
            EditCommand = new RelayCommand(EditMethod);
            ClearCommand = new RelayCommand(ClearMethod);
            CloseCommand = new RelayCommand(CloseMethod);
            DeleteCommand = new RelayCommand(DeleteMethod);
            IsEnableNew = IsEnableEdit = true;
            IsEnableDelete = false;
            addItemsToList();
        }



        public int Id
        {
            get { return _Spotter.Id; }
            set
            {
                _Spotter.Id = value;
                RaisePropertyChanged("Id");
                ValidateModelProperty(value, "Id", _Spotter);
            }
        }

        public int MakeId
        {
            get { return _Spotter.MakeId; }
            set
            {
                _Spotter.MakeId = value;
                RaisePropertyChanged("MakeId");
                ValidateModelProperty(value, "MakeId", _Spotter);
            }
        }

        public int ModelId
        {
            get { return _Spotter.ModelId; }
            set
            {
                _Spotter.ModelId = value;
                RaisePropertyChanged("ModelId");
                ValidateModelProperty(value, "ModelId", _Spotter);
            }
        }

        public string Location
        {
            get { return _Spotter.Location; }
            set
            {
                _Spotter.Location = value;
                RaisePropertyChanged("Location");
                ValidateModelProperty(value, "Location", _Spotter);
            }
        }
        public string Registration
        {
            get { return _Spotter.Registration; }
            set
            {
                _Spotter.Registration = value;
                RaisePropertyChanged("Registration");
                ValidateModelProperty(value, "Registration", _Spotter);
            }
        }

        public DateTime Date
        {
            get { return _Spotter.Date; }
            set
            {
                _Spotter.Date = value;
                RaisePropertyChanged("Date");
                ValidateModelProperty(value, "Date", _Spotter);
            }
        }


        #region Button Command
        private RelayCommand _ClearCommand;
        public RelayCommand ClearCommand
        {
            get { return _ClearCommand; }
            set { _ClearCommand = value; }
        }

        private RelayCommand _EditCommand;
        public RelayCommand EditCommand
        {
            get { return _EditCommand; }
            set { _EditCommand = value; }
        }

        private RelayCommand _NewCommand;
        public RelayCommand NewCommand
        {
            get { return _NewCommand; }
            set { _NewCommand = value; }
        }

        private RelayCommand _SaveCommand;
        public RelayCommand SaveCommand
        {
            get { return _SaveCommand; }
            set { _SaveCommand = value; }
        }
        private RelayCommand _CloseCommand;
        public RelayCommand CloseCommand
        {
            get { return _CloseCommand; }
            set { _CloseCommand = value; }
        }
        private RelayCommand _DeleteCommand;
        public RelayCommand DeleteCommand
        {
            get { return _DeleteCommand; }
            set { _DeleteCommand = value; }
        }
        #endregion

        #region Button Enable Desable properties
        private bool _IsEnableNew;
        public bool IsEnableNew
        {
            get { return _IsEnableNew; }
            set { _IsEnableNew = value; RaisePropertyChanged("IsEnableNew"); }
        }

        private bool _IsEnableSave;
        public bool IsEnableSave
        {
            get { return _IsEnableSave; }
            set { _IsEnableSave = value; RaisePropertyChanged("IsEnableSave"); }
        }

        private bool _IsEnableEdit;
        public bool IsEnableEdit
        {
            get { return _IsEnableEdit; }
            set { _IsEnableEdit = value; RaisePropertyChanged("IsEnableEdit"); }
        }

        private bool _IsEnableClear;
        public bool IsEnableClear
        {
            get { return _IsEnableClear; }
            set { _IsEnableClear = value; RaisePropertyChanged("IsEnableClear"); }
        }
        private bool _IsEnableDelete;
        public bool IsEnableDelete
        {
            get { return _IsEnableDelete; }
            set { _IsEnableDelete = value; RaisePropertyChanged("IsEnableDelete"); }
        }
        #endregion

        #region Methods

        private void CloseMethod(object obj)
        {
            //this.te
        }
        private void ClearMethod(object obj)
        {
            IsEnableNew = IsEnableDelete = IsEnableEdit = true;
            IsEnableSave = IsEnableClear = false;
            FormState = FormStateEnum.Clear;
            Location = null;
            Registration = null;
            ModelId = 0;
            MakeId = 0;
            Id = 0;
            Date = System.DateTime.Now;
        }

        private void EditMethod(object obj)
        {
            IsEnableNew = IsEnableDelete = IsEnableEdit = false;
            IsEnableSave = IsEnableClear = true;
            FormState = FormStateEnum.Update;
        }

        private void NewMethod(object obj)
        {
            IsEnableNew = IsEnableDelete = IsEnableEdit = false;
            IsEnableSave = IsEnableClear = true;
            FormState = FormStateEnum.New;
            Location = null;
            Registration = null;
            ModelId = 0;
            MakeId = 0;
            Id = 0;
            Date = System.DateTime.Now;
        }
        private void DeleteMethod(object obj)
        {
            if (FormState == FormStateEnum.Delete)
            {
                SpotterTypeList.Remove(SpotterTypeList.First(z => z.Id == Id));
            }
            addItemsToList();
        }

        private void SaveMethod(object obj)
        {
            // ValidateModel(_Fedexlocation);
            IsEnableNew = IsEnableDelete = IsEnableEdit = true;//try to move from one location
            //IsEnableClear = IsCodeEnable = IsGridEnable = false;
            FormState = (FormState != FormStateEnum.Update) ? FormStateEnum.Save : FormStateEnum.Update;

            SpotterEntity spotterEntity = new SpotterEntity();
            spotterEntity.Location = Location;
            spotterEntity.Registration = Registration;
            spotterEntity.ModelId = ModelId;
            spotterEntity.MakeId = MakeId;
            spotterEntity.Date = Date;

            if (FormState == FormStateEnum.Update)
            {
                spotterEntity.Id = Id;
                SpotterTypeList.Remove(SpotterTypeList.First(z => z.Id == Id));
                SpotterTypeList.Add(spotterEntity);
            }
            else if (FormState == FormStateEnum.Save)
            {
                spotterEntity.Id = SpotterTypeList.Max(z => z.Id) + 1;
                SpotterTypeList.Add(spotterEntity);
            }
            addItemsToList();
        }

        #endregion

        #region List Properties

        private SpotterEntity _SelectedspotterEntityItem;
        public SpotterEntity SelectedspotterEntityItem
        {
            get { return _SelectedspotterEntityItem; }
            set
            {
                _SelectedspotterEntityItem = value; this.RaisePropertyChanged("SelectedspotterEntityItem");
                if (SelectedspotterEntityItem != null)
                {
                    Location = SelectedspotterEntityItem.Location;
                    Registration = SelectedspotterEntityItem.Registration;
                    ModelId = SelectedspotterEntityItem.ModelId;
                    MakeId = SelectedspotterEntityItem.MakeId;
                    Date = SelectedspotterEntityItem.Date;
                    Id = SelectedspotterEntityItem.Id;
                }
            }
        }


        private List<SpotterEntity> _SpotterTypeList;
        public List<SpotterEntity> SpotterTypeList
        {
            get { return _SpotterTypeList; }
            set { _SpotterTypeList = value; this.RaisePropertyChanged("SpotterTypeList"); }
        }

        private List<ModelEntity> _ModelTypeList;
        public List<ModelEntity> ModelTypeList
        {
            get { return _ModelTypeList; }
            set { _ModelTypeList = value; this.RaisePropertyChanged("ModelTypeList"); }
        }

        private ObservableCollection<ModelEntity> _ModelTypeDataList;
        public ObservableCollection<ModelEntity> ModelTypeDataList
        {
            get { return _ModelTypeDataList = new ObservableCollection<ModelEntity>(ModelTypeList); }
            set { _ModelTypeDataList = value; this.RaisePropertyChanged("ModelTypeDataList"); }
        }
        private ModelEntity _SelectedModel;

        public ModelEntity SelectedModel
        {
            get { return _SelectedModel; }
            set { _SelectedModel = value; this.RaisePropertyChanged("SelectedModel"); }
        }

        private MakeEntity _SelectedMake;
        public MakeEntity SelectedMake
        {
            get { return _SelectedMake; }
            set { _SelectedMake = value; this.RaisePropertyChanged("SelectedMake"); }
        }


        private List<MakeEntity> _MakeTypeList;
        public List<MakeEntity> MakeTypeList
        {
            get { return _MakeTypeList; }
            set { _MakeTypeList = value; this.RaisePropertyChanged("MakeTypeList"); }
        }

        private ObservableCollection<MakeEntity> _MakeTypeDataList;
        public ObservableCollection<MakeEntity> MakeTypeDataList
        {
            get { return _MakeTypeDataList = new ObservableCollection<MakeEntity>(MakeTypeList); }
            set { _MakeTypeDataList = value; this.RaisePropertyChanged("MakeTypeDataList"); }
        }

        private ObservableCollection<SpotterEntity> _SpotterTypeDataList;
        public ObservableCollection<SpotterEntity> SpotterTypeDataList
        {
            get { return _SpotterTypeDataList = new ObservableCollection<SpotterEntity>(SpotterTypeList); }
            set { _SpotterTypeDataList = value; this.RaisePropertyChanged("SpotterTypeDataList"); }
        }


        private List<SerchTypeEntity> _SerchTypeList;
        public List<SerchTypeEntity> SerchTypeList
        {
            get { return _SerchTypeList; }
            set { _SerchTypeList = value; this.RaisePropertyChanged("SerchTypeList"); }
        }

        private ObservableCollection<SerchTypeEntity> _SerchTypeDataList;
        public ObservableCollection<SerchTypeEntity> SerchTypeDataList
        {
            get { return _SerchTypeDataList = new ObservableCollection<SerchTypeEntity>(SerchTypeList); }
            set { _SerchTypeDataList = value; this.RaisePropertyChanged("SerchTypeDataList"); }
        }

        private SerchTypeEntity _SelectedSerchType;
        public SerchTypeEntity SelectedSerchType
        {
            get { return _SelectedSerchType; }
            set { _SelectedSerchType = value; this.RaisePropertyChanged("SelectedSerchType"); }
        }

        private string _SerchText;
        public string SerchText
        {
            get { return _SerchText; }
            set { _SerchText = value; this.RaisePropertyChanged("SerchText");
            if(SerchText!="")
                {
                    if(SelectedSerchType.Name=="Location")
                    {
                        SpotterTypeList= SpotterTypeList.Where(z => z.Location == SerchText).ToList();
                    }
                    else if(SelectedSerchType.Name == "Registration")
                    {
                        SpotterTypeList = SpotterTypeList.Where(z => z.Registration == SerchText).ToList();
                    }
                    spotterGridRefresh();
                }
            else
                {
                    addItemsToList();
                }
            }
        }

        private void spotterGridRefresh()
        {
            SpotterTypeDataList = new ObservableCollection<SpotterEntity>(SpotterTypeList);
            MakeTypeDataList = new ObservableCollection<MakeEntity>(MakeTypeList);
            ModelTypeDataList = new ObservableCollection<ModelEntity>(ModelTypeList);
            SerchTypeDataList = new ObservableCollection<SerchTypeEntity>(SerchTypeList);
            SelectedSerchType = SerchTypeDataList.First();
        }

        #endregion

        private FormStateEnum _FormState;
        public FormStateEnum FormState
        {
            get { return _FormState; }
            set { _FormState = value; }

        }

        public void addItemsToList()
        {
            SerchTypeList.Add(new SerchTypeEntity { Id = 1, Name = "Location" });
            SerchTypeList.Add(new SerchTypeEntity { Id = 2, Name = "Registration" });
            SerchTypeList.Add(new SerchTypeEntity { Id = 3, Name = "Make" });

            MakeTypeList.Add(new MakeEntity { Id = 1, Name = "Boeing", IsActive = true });


            ModelTypeList.Add(new ModelEntity { Id = 1, Name = "777-300ER", IsActive = true });


            SpotterTypeList.Add(new SpotterEntity { Id = 1, Date = DateTime.Parse("2022-05-04"), MakeId = 1, Location = "London Gatwick", ModelId = 1, Registration = "G - RNAC" });
            SpotterTypeList.Add(new SpotterEntity { Id = 2, Date = DateTime.Parse("2022-05-05"), MakeId = 1, Location = "London Gatwick", ModelId = 1, Registration = "G - RNAC" });
            SpotterTypeList.Add(new SpotterEntity { Id = 3, Date = DateTime.Parse("2022-05-06"), MakeId = 1, Location = "London Gatwick", ModelId = 1, Registration = "G - RNAC" });
            spotterGridRefresh();
        }

        // need to implimet Proxicy manager for this but don't have time to do it 
        //public async Task<List<SpotterEntity>> list GetSpotterListFromApi()
        //{
        //    using (var client = new HttpClient())
        //    {
        //        Uri requetUrl = new Uri("https://localhost:44381/Spotter/GetSpotter/");
        //        var responseFromResourceServer = await client.GetStringAsync(requetUrl);
        //        // var res JsonConvert.DeserializeObject<List<ServiceResponse>>(responseFromResourceServer);
        //        SpotterTypeList= new List<SpotterEntity>();
        //    }

        //}
    }
}
