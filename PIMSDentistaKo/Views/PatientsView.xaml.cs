﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using pimsdentistako.Windows;

using pimsdentistako.DBHelpers;
using pimsdentistako.DBElements;

namespace pimsdentistako.Views
{
    /// <summary>
    /// Interaction logic for PatientsView.xaml
    /// </summary>
    public partial class PatientsView : UserControl
    {
        public PatientsView()
        {
            InitializeComponent();
            DatabaseHelper.Init();
            PatientHelper.MyDataGrid = patientDataGrid;
            PatientHelper.TextCount = txtTotalPatient; //attach the count textblock to auto update whenever the list changes
            PatientHelper.MyComboBox = searchByComboBox;
            PatientHelper.InitList();
        }

        private void patientDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            PatientHelper.ListenToDataGrid();
            PatientHelper.DisplaySelected(nameTxtBox,MiddleName,LastName,Suffix,Nickname,Sex,CivilStatus,Address,Email,MobileNumber,HomeNumber,DateOfBirth,RefferedBy,Occupation,Company,OfficeNumber,FaxNumber,Age);
        }

        private void searchButton_Click(object sender, RoutedEventArgs e)
        {
            PatientHelper.ListenToSearch(txtBoxSearch);
        }

        private void clearSearchButton_Click(object sender, RoutedEventArgs e)
        {
            PatientHelper.ListenToClearSearch(txtBoxSearch);
        }

        private void searchByComboBox_SelChanged(object sender, SelectionChangedEventArgs e)
        {
            PatientHelper.ListenToComboBoxSelection(searchTxt);
        }

        private void AddPatientButton_Click(object sender, RoutedEventArgs e)
        {
            AddPatientWindow addPatientView = new AddPatientWindow();
            addPatientView.Show();
        }

        private void editPatientButton_Click(object sender, RoutedEventArgs e)
        {
            EditPatientWindow editPatientWindow = new EditPatientWindow();
            editPatientWindow.Show();
        }

        private void deletePatient_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Deleted.");
        }

        private void dentalRecordButton_Click(object sender, RoutedEventArgs e)
        {
            DentalRecordsWindow dentalRecordsWindow = new DentalRecordsWindow();
            dentalRecordsWindow.Show();
        }
    }
}
