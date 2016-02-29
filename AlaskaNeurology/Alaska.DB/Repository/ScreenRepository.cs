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
 

    public class ScreenRepository 
    {
        #region private variables
        private readonly AlaskaContext _context;
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
        public ScreenRepository(int screenid, AlaskaContext context)
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
        public string GetListofControls()
        {
            screenConfiguration = _context.screenConfiguration.Where(a => a.ScreenId == _screenid).SingleOrDefault();
            screenControlDBMapperList = _context.screenControlDBMapper.Where(sc=>sc.FKScreenId==_screenid).ToList();
            var modelCtrlList = screenControlDBMapperList.Select(a => a.FKScreenModelControlId);
            screenTableMapperList = _context.screenTableMapper.Where(x => modelCtrlList.Contains(x.ScreenModelControlId)).ToList();
            var modelidlist = screenTableMapperList.Select(a => a.FKScreenModelId);
            var controlidlist = screenTableMapperList.Select(a => a.FKControlTypeId);

            screenDomainModelList = _context.screenDomainModel.Where(x=> modelidlist.Contains(x.ScreenModelID)).ToList();
            controlTypeList = _context.controlType.Where(x=> controlidlist.Contains(x.PkControlTypeId)).ToList();
            controlsDictionary = new Dictionary<ScreenControlDBMapper, string>();
            string hText = null;
           // hText += $@"@model Alaska.Model.DataModel.{screenDomainModelList.Single().ModelName + Environment.NewLine}";
            foreach (var item in screenTableMapperList)
                {
                string tempstr = null;
                var type = controlTypeList.Where(x => x.PkControlTypeId == item.FKControlTypeId).Single().ControlType.ToString().ToUpper();
                 if (type == Constant.TEXTBOX.ToString())
                    {
                    tempstr += $@"<input asp-for={item.ModelProperty}/>";
                    }
                else if (type == Constant.LABEL.ToString())
                    {
                    tempstr += $@"<label>{item.ModelProperty}</label>";
                    }
                hText += tempstr;
                }
          
            return hText;
        }

        public string GenerateScreenLayout()
        {
            var ctrllist = GetListofControls();
            StringBuilder htmllbl = new StringBuilder();
            StringBuilder htmlinput = new StringBuilder();
            //foreach (var item in ctrllist.Keys)
            //{
            //    //if(ctrllist[item].Trim().ToUpper()== Constant.TEXTBOX.ToString())
            //    //{
            //    //    htmllbl.Append($@"<div style='padding - top: 10px; '><label id='{item.LabelId}'> {item.LabelText}</label></div>");
            //    //    htmlinput.Append($@"<div style='padding - top: 10px; '><input type='text' id='{item.ControlId}'/></div>");
                 
            //    //}
            //    //else if (ctrllist[item].Trim().ToUpper() == Constant.TEXTAREA.ToString())
            //    //{
            //    //    htmllbl.Append($@"<div style='padding - top: 10px; '><label id='{item.LabelId}'> {item.LabelText}</label></div>");
            //    //    htmlinput.Append($@"<div style='padding - top: 10px; '><textarea id= '{item.ControlId}' > </textarea></div>");
       
            //    //}
            //    //else if (ctrllist[item].Trim().ToUpper() == Constant.BUTTON.ToString())
            //    //{
            //    //    htmlinput.Append($@"<div style='padding - top: 10px; '> <input type = 'button' value = 'SUBMIT'/></div>");
            //    //}

            //}
            var res= $@"<div style='float:left'>{htmllbl.ToString()}</div>"+ $@"<div style='float:right'>{htmlinput.ToString()}</div>";
            return ctrllist;
        }
        #endregion

    }
}
