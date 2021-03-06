﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OcrApi.Models;

namespace OcrApi
{
    public partial class OcrApiServiceForm : Form
    {
        private OcrApiServiceManager _formManager;
        private PostImageModel _formModel;
        public OcrApiServiceForm()
        {
            _formManager = new OcrApiServiceManager();
            _formModel = _formManager.LoadLastRequest();
            InitializeComponent();
            SetControlsNames();
            _apiCodeTextBox.Text = _formModel.ApiKey;
            _languageCodeTextBox.Text = _formModel.LanguageCode;
            _selectFileTextBox.Text = _formManager.GetFilePath(_formModel);
        }

        private void SetControlsNames()
        {
            this._sendButton.Text = ControlsResource.SEND_BUTTON;
            this._apiCodeLabel.Text = ControlsResource.API_CODE_LABEL;
            this._languageCodeLabel.Text = ControlsResource.LANGUAGE_CODE_LABEL;
            this._browseButton.Text = ControlsResource.BROWSE_BUTTON;
            this._selectFileLabel.Text = ControlsResource.SELECT_FILE_LABEL;
            this._requestGroupBox.Text = ControlsResource.REQUEST_LABEL;
            this._responseGroupBox.Text = ControlsResource.RESULT_LABEL;
            this.Text = ControlsResource.OCR_API_SERVICE;
        }

        private void _browseButton_Click(object sender, EventArgs e)
        {
            _selectFileTextBox.Text = _formManager.BrowseFile(_formModel);
        }

        private void _apiCodeTextBox_TextChanged(object sender, EventArgs e)
        {
            _formModel.ApiKey = _apiCodeTextBox.Text;
        }

        private void _languageCodeTextBox_TextChanged(object sender, EventArgs e)
        {
            _formModel.LanguageCode = _languageCodeTextBox.Text;
        }

        private void _selectFileTextBox_TextChanged(object sender, EventArgs e)
        {
            _formModel.PicturePath = _selectFil.eTextBox.Text;
        }

        private void _sendButton_Click(object sender, EventArgs e)
        {
            _panel.Enabled = false;
            _responseTextBox.Text = _formManager.SendImage(_formModel);
            _panel.Enabled = true;
        }
    }
}
