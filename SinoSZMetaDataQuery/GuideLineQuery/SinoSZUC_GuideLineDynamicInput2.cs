﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using SinoSZJS.Base.MetaData.QueryModel;
using SinoSZJS.Base.MetaData.Common;

namespace SinoSZMetaDataQuery.GuideLineQuery
{
        public partial class SinoSZUC_GuideLineDynamicInput2 : UserControl
        {
                private MD_GuideLine guideLineDefine = null;
                private List<MD_GuideLineParameter> ParameterDefines = null;
                private Color LabelColor = Color.Black;
                public SinoSZUC_GuideLineDynamicInput2()
                {
                        InitializeComponent();
                }


                public bool InputFinised
                {
                        get
                        {
                                bool _ret = true;
                                foreach (Control _c in this.Controls)
                                {
                                        SinoSZUC_GLQD_InputItem _inputItem = _c as SinoSZUC_GLQD_InputItem;
                                        _ret = (_ret && _inputItem.HaveInputData);
                                }
                                return _ret;
                        }
                }

                public int ItemCount
                {
                        get
                        {
                                return this.Controls.Count;
                        }
                }

                public void InitForm(string paramStrings)
                {
                        if (paramStrings == null || paramStrings == "")
                        {
                                this.Controls.Clear();
                                this.Height = 5;
                                return;
                        }
                        ParameterDefines = MC_GuideLine.GetParametersFromMeta(paramStrings);
                        ShowItems();
                }

                public void InitForm(MD_GuideLine _guideLine)
                {

                        if (_guideLine == null)
                        {
                                this.Controls.Clear();
                                this.Height = 5;
                                return;
                        }

                        guideLineDefine = _guideLine;
                        ParameterDefines = MC_GuideLine.GetParametersFromMeta(_guideLine.GuideLineMeta);
                        ShowItems();
                }

                public void ShowItems()
                {
                        this.Controls.Clear();
                        this.Height = 24;

                        foreach (MD_GuideLineParameter _glp in ParameterDefines)
                        {
                                switch (_glp.ParameterType)
                                {
                                        case "逻辑型":
                                                break;
                                        case "代码表":
                                                SinoSZUC_GLQD_InputRefTable _refitem = new SinoSZUC_GLQD_InputRefTable(_glp);
                                                _refitem.InputChanged += new EventHandler(_dateitem_InputChanged);
                                                _refitem.Dock = DockStyle.Right;
                                                _refitem.LabelColor = this.LabelColor;
                                                this.Controls.Add(_refitem);
                                                _refitem.SendToBack();
                                                break;
                                        case "日期型":
                                                SinoSZUC_GLQD_InputDate _dateitem = new SinoSZUC_GLQD_InputDate(_glp);
                                                _dateitem.InputChanged += new EventHandler(_dateitem_InputChanged);
                                                _dateitem.Dock = DockStyle.Right;
                                                _dateitem.LabelColor = this.LabelColor;
                                                this.Controls.Add(_dateitem);
                                                _dateitem.SendToBack();
                                                break;
                                        case "单位型(全部)":
                                        case "单位型(权限范围)":
                                        case "单位ID型(缉私局权限)":
                                        case "单位ID型(全部)":
                                        case "单位ID型(权限范围)":
                                        case "单位代码型(全部)":
                                        case "单位代码型(权限范围)":
                                                SinoSZUC_GLQD_InputOrg _orgItem = new SinoSZUC_GLQD_InputOrg(_glp, _glp.ParameterType);
                                                _orgItem.Dock = DockStyle.Right;
                                                _orgItem.InputChanged += new EventHandler(_dateitem_InputChanged);
                                                _orgItem.LabelColor = this.LabelColor;
                                                this.Controls.Add(_orgItem);
                                                _orgItem.SendToBack();
                                                break;
                                        default:
                                                SinoSZUC_GLQD_InputItem _item = new SinoSZUC_GLQD_InputItem(_glp);
                                                _item.Dock = DockStyle.Right;
                                                _item.InputChanged += new EventHandler(_dateitem_InputChanged);
                                                _item.LabelColor = this.LabelColor;
                                                this.Controls.Add(_item);
                                                _item.SendToBack();
                                                break;
                                }
                        }
                }

                void _dateitem_InputChanged(object sender, EventArgs e)
                {
                        this.RaiseInputChanged();
                }


                [Category("WinFormEx")]
                public event EventHandler InputChanged;
                protected void RaiseInputChanged()
                {
                        EventArgs e = new EventArgs();
                        if (InputChanged != null)
                                InputChanged(this, e);
                }

                public List<MDQuery_GuideLineParameter> GetParamters()
                {
                        List<MDQuery_GuideLineParameter> _ret = new List<MDQuery_GuideLineParameter>();
                        foreach (Control _c in this.Controls)
                        {
                                SinoSZUC_GLQD_InputItem _inputItem = _c as SinoSZUC_GLQD_InputItem;
                                MDQuery_GuideLineParameter _cs = _inputItem.GetParameter();
                                _ret.Add(_cs);
                        }
                        return _ret;
                }

                public void WriteParamValue(string _Params)
                {
                        List<MDQuery_GuideLineParameter> _pList = MC_GuideLine.CreateQueryParameter(guideLineDefine, _Params);
                        foreach (MDQuery_GuideLineParameter _pa in _pList)
                        {
                                SetParamValue(_pa);
                        }
                }

                public void WriteParamValue(string _pname, string _value)
                {
                        foreach (Control _c in this.Controls)
                        {
                                SinoSZUC_GLQD_InputItem _inputItem = _c as SinoSZUC_GLQD_InputItem;
                                if (_inputItem.ParamDefine.ParameterName == _pname)
                                {
                                        _inputItem.SetValue(_value);
                                }
                        }
                }

                private void SetParamValue(MDQuery_GuideLineParameter _pa)
                {
                        foreach (Control _c in this.Controls)
                        {
                                SinoSZUC_GLQD_InputItem _inputItem = _c as SinoSZUC_GLQD_InputItem;
                                if (_inputItem.ParamDefine.ParameterName == _pa.Paramter.ParameterName)
                                {
                                        _inputItem.SetValue(_pa.Data);
                                }
                        }
                }

                public void SetLabelColor(Color _color)
                {
                        this.LabelColor = _color;
                }
        }
}
