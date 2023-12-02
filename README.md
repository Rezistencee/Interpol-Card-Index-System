# Interpol-Card-Index-System
***
This project use **WPF technology** and **MVVM pattern**.

Project functionality: 
- Authorization in the system.
- Viewing small statistics in the database (in this case in RAM).
- Viewing a list of criminals and the ability to add them.
- Viewing a list of criminal groups and adding them.

Project Structure:
1. Models
  - Criminals
  - CriminalGroup
  - User
2. Services:
  - RepositoryService (store information)
  - CollectionFilter (filter collection items through predicates)
  - Session (store current session info)
3. ViewModels
  - LoginWindowViewModel
  - MainWindowViewModel
  - AddNewCriminalGroupViewModel
  - AddNewCriminalViewModel
  - CriminalWindowViewModel
  - CriminalGroupsViewModel
4. Views
  - LoginWindow
  - MainWindow
  - AddNewCriminal
  - AddNewCriminalGroup
  - CriminalGroup_Information
  - Criminal_Information
  - CriminalGroupsWindow
  - CriminalWindow
