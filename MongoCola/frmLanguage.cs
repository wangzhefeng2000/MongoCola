﻿using System;
using System.IO;
using System.Windows.Forms;
using MongoCola.Config;

namespace MongoCola
{
    public partial class FrmLanguage : Form
    {
        public FrmLanguage()
        {
            InitializeComponent();
        }

        /// <summary>
        ///     加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmLanguage_Load(object sender, EventArgs e)
        {
            cmbLanguage.Text = "English";
            cmbLanguage.Items.Add("English");
            if (!Directory.Exists("Language")) return;
            foreach (var fileName in Directory.GetFiles("Language"))
            {
                cmbLanguage.Items.Add(new FileInfo(fileName).Name.Substring(0,
                    new FileInfo(fileName).Name.Length - 4));
            }
        }

        /// <summary>
        ///     OK
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdOK_Click(object sender, EventArgs e)
        {
            SystemConfig.Config.LanguageFileName = cmbLanguage.Text + ".xml";
            ConfigHelper.SaveToConfigFile();
            Close();
        }
    }
}