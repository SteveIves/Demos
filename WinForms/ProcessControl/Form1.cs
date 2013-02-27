using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Windows.Forms;

namespace ProcessControl
{
    public partial class Form1 : Form
    {
        private ServiceController service;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            service = new ServiceController("AcrSch2Svc");

            checkStatus();

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            service.Close();
        }

        private void checkStatus()
        {
            btnContinue.Enabled = false;
            btnPause.Enabled = false;
            btnStart.Enabled = false;
            btnStop.Enabled = false;
            
            switch (service.Status)
            {
                case ServiceControllerStatus.StartPending:
                    lblServiceStatus.Text = "Start pending";
                    break;
                case ServiceControllerStatus.Running:
                    lblServiceStatus.Text = "Running";
                    if (service.CanStop)
                        btnStop.Enabled = true;
                    if (service.CanPauseAndContinue)
                        btnPause.Enabled = true;
                    break;
                case ServiceControllerStatus.PausePending:
                    lblServiceStatus.Text = "Pause pending";
                    break;
                case ServiceControllerStatus.Paused:
                    lblServiceStatus.Text = "Paused";
                    btnContinue.Enabled = true;
                    if (service.CanStop)
                        btnStop.Enabled = true;
                    break;
                case ServiceControllerStatus.ContinuePending:
                    lblServiceStatus.Text = "Continue pending";
                    break;
                case ServiceControllerStatus.StopPending:
                    lblServiceStatus.Text = "Stop pending";
                    break;
                case ServiceControllerStatus.Stopped:
                    lblServiceStatus.Text = "Stopped";
                    btnStart.Enabled = true;
                    break;
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            try
            {
                TimeSpan timeout = TimeSpan.FromMilliseconds(5000);
                service.Start();
                service.WaitForStatus(ServiceControllerStatus.Running, timeout);
                checkStatus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to start. " + ex.Message);
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            try
            {
                TimeSpan timeout = TimeSpan.FromMilliseconds(5000);
                service.Stop();
                service.WaitForStatus(ServiceControllerStatus.Stopped, timeout);
                checkStatus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to stop. " + ex.Message);
            }
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            try
            {
                TimeSpan timeout = TimeSpan.FromMilliseconds(5000);
                service.Pause();
                service.WaitForStatus(ServiceControllerStatus.Paused, timeout);
                checkStatus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to pause. " + ex.Message);
            }
        }

        private void btnContinue_Click(object sender, EventArgs e)
        {
            try
            {
                TimeSpan timeout = TimeSpan.FromMilliseconds(5000);
                service.Continue();
                service.WaitForStatus(ServiceControllerStatus.Running, timeout);
                checkStatus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to resume. " + ex.Message);
            }
        }

        private void stopProcessByName(String programName)
        {
            Process[] matchingProcesses;
            // Returns array containing all instances of Notepad.
            matchingProcesses = Process.GetProcessesByName(programName);
            foreach (Process thisProcess in matchingProcesses)
            {
                thisProcess.Kill();
            }
        }

    }
}
