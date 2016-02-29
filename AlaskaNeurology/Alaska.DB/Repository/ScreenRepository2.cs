using Alaska.DB.Infrastructure;
using Alaska.Interface.Repository;
using Alaska.Model.CommonModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Text;

namespace Alaska.DB.Repository
{
 

    public class ScreenRepository2 
    {
        #region private variables
        private readonly AlaskaContext _context;
        private Repository<ScreenConfiguration> screenConfigurationRepository;
        private Repository<ScreenControlDBMapper> screenControlDBMapperRepository;
        private Repository<ScreenTableMapper> screenTableMapperRepository;
        private Repository<ScreenDomainModel> sreenDomainModelRepository;

        private Repository<LControlType> controlTypeRepository;
        private ScreenConfiguration screenConfiguration;
        
        private ScreenTableMapper screenTableMapper;
        private IEnumerable<ScreenTableMapper> screenTableMapperList;
        private IEnumerable<ScreenDomainModel> screenDomainModelList;
        private IEnumerable<ScreenControlDBMapper> screenControlDBMapperList=null;

        private IEnumerable<LControlType> controlTypeList = null;
        private int _screenid = -255;
        private Dictionary<ScreenControlDBMapper, string> controlsDictionary = null;
        #endregion
        #region Properties
        public Repository<ScreenConfiguration> ScreenConfigurationRepository
        {
            get
            {

                if (screenConfigurationRepository == null)
                {
                    screenConfigurationRepository = new Repository<ScreenConfiguration>(_context);
                }
                return screenConfigurationRepository;
            }
        }
        public Repository<ScreenControlDBMapper> ScreenControlDBMapperRepository
        {
            get
            {
                if (this.screenControlDBMapperRepository == null)
                {
                    this.screenControlDBMapperRepository = new Repository<ScreenControlDBMapper>(_context);
                }
                return screenControlDBMapperRepository;
            }
        }
        public Repository<ScreenTableMapper> ScreenTableMapperRepository
        {
            get
            {

                if (this.screenTableMapperRepository == null)
                {
                    this.screenTableMapperRepository = new Repository<ScreenTableMapper>(_context);
                }
                return screenTableMapperRepository;
            }
        }
        public Repository<ScreenDomainModel> ScreenDomainModelRepository
            {
            get
                {

                if (this.sreenDomainModelRepository == null)
                    {
                    this.sreenDomainModelRepository = new Repository<ScreenDomainModel>(_context);
                    }
                return sreenDomainModelRepository;
                }
            }
        public Repository<LControlType> ControlTypeRepository
        {
            get
            {

                if (this.controlTypeRepository == null)
                {
                    this.controlTypeRepository = new Repository<LControlType>(_context);
                }
                return controlTypeRepository;
            }
        }
        #endregion
        #region enumerations
        enum Constant
        {
            TEXTBOX,
            LABEL,
            BUTTON,
            GRID,
            TEXTAREA,
            DROPDOWNBOX
        }
        #endregion
        #region Constructor
        public ScreenRepository2(int screenid, AlaskaContext context)
        {
            _screenid = screenid;
            _context = context;
        }
        #endregion
        #region public methods
        /// <summary>
        /// Get list of controls from database 
        /// </summary>
        /// <returns> set of  screenControlDBMapper model</returns>
        public Dictionary<ScreenControlDBMapper, string> GetListofControls()
        {
            screenConfiguration = ScreenConfigurationRepository.All().Where(a => a.ScreenId == _screenid).SingleOrDefault();
            screenControlDBMapperList = ScreenControlDBMapperRepository.All().Where(sc=>sc.FKScreenId==_screenid);
            var modelCtrlList = screenControlDBMapperList.Select(a => a.FKScreenModelControlId);
            screenTableMapperList = ScreenTableMapperRepository.All().Where(x => modelCtrlList.Contains(x.ScreenModelControlId));
            var modelidlist = screenTableMapperList.Select(a => a.FKScreenModelId);
            var controlidlist = screenTableMapperList.Select(a => a.FKControlTypeId);

            screenDomainModelList = ScreenDomainModelRepository.All().Where(x=> modelidlist.Contains(x.ScreenModelID));
            controlTypeList = ControlTypeRepository.All().Where(x=> controlidlist.Contains(x.PkControlTypeId));
            controlsDictionary = new Dictionary<ScreenControlDBMapper, string>();

           //foreach (var item in screenControlDBMapperList)
            //{
            //    var s = controlTypeList.Where(i => (i.PkControlTypeId) == item.ControlTypeId).First();
            //    controlsDictionary.Add(item, s.ControlType);
            //}
            return controlsDictionary;
        }

        public string GenerateScreenLayout()
        {
            var ctrllist = GetListofControls();
            StringBuilder htmllbl = new StringBuilder();
            StringBuilder htmlinput = new StringBuilder();
            foreach (var item in ctrllist.Keys)
            {
                //if(ctrllist[item].Trim().ToUpper()== Constant.TEXTBOX.ToString())
                //{
                //    htmllbl.Append($@"<div style='padding - top: 10px; '><label id='{item.LabelId}'> {item.LabelText}</label></div>");
                //    htmlinput.Append($@"<div style='padding - top: 10px; '><input type='text' id='{item.ControlId}'/></div>");
                 
                //}
                //else if (ctrllist[item].Trim().ToUpper() == Constant.TEXTAREA.ToString())
                //{
                //    htmllbl.Append($@"<div style='padding - top: 10px; '><label id='{item.LabelId}'> {item.LabelText}</label></div>");
                //    htmlinput.Append($@"<div style='padding - top: 10px; '><textarea id= '{item.ControlId}' > </textarea></div>");
       
                //}
                //else if (ctrllist[item].Trim().ToUpper() == Constant.BUTTON.ToString())
                //{
                //    htmlinput.Append($@"<div style='padding - top: 10px; '> <input type = 'button' value = 'SUBMIT'/></div>");
                //}

            }
            var res= $@"<div style='float:left'>{htmllbl.ToString()}</div>"+ $@"<div style='float:right'>{htmlinput.ToString()}</div>";
            return res;
        }
        #endregion

    }
}
