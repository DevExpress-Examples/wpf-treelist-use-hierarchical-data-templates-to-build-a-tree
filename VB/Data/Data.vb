﻿Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Collections.ObjectModel
Imports System.ComponentModel
Imports System.Collections
Imports System.Xml.Serialization
Imports System.Reflection
Imports System.Windows.Media.Imaging
Imports System.Windows.Media
Imports System.Collections.Specialized

Namespace HierarchicalDataTemplateMode
	Public Class BaseObject
		Implements INotifyPropertyChanged

		Private nameCore As String
		Public Property Name() As String
			Get
				Return nameCore
			End Get
			Set(ByVal value As String)
				If Name = value Then
					Return
				End If
				nameCore = value
				OnPropertyChanged("Name")
			End Set
		End Property

		Private executorCore As String
		Public Property Executor() As String
			Get
				Return executorCore
			End Get
			Set(ByVal value As String)
				If ReferenceEquals(Executor, value) Then
					Return
				End If
				executorCore = value
				OnPropertyChanged("Executor")
			End Set
		End Property

		Public Overrides Function ToString() As String
			Return Name
		End Function

		Protected Sub OnPropertyChanged(ByVal propertyName As String)
			RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(propertyName))
		End Sub

		Private ownerCore As ProgressingObject
		Public Property Owner() As ProgressingObject
			Get
				Return ownerCore
			End Get
			Set(ByVal value As ProgressingObject)
				If ReferenceEquals(Owner, value) Then
					Return
				End If
				ownerCore = value
				OnPropertyChanged("Owner")
			End Set
		End Property

		Public Event PropertyChanged As PropertyChangedEventHandler
	End Class

	Public Class ProgressingObject
		Inherits BaseObject

		Private progressCore As Integer

		Public Overridable Sub UpdateProgress()
		End Sub

		Public Property Progress() As Integer
			Get
				Return progressCore
			End Get
			Set(ByVal value As Integer)
				If ReferenceEquals(Progress, value) Then
					Return
				End If
				progressCore = value
				OnPropertyChanged("Progress")
				If Owner IsNot Nothing Then
					Owner.UpdateProgress()
				End If
			End Set
		End Property
	End Class

	Public Class ProjectObject
		Inherits ProgressingObject

		Public Sub New()
			Stages = New ObservableCollection(Of ProjectStage)()
			AddHandler Stages.CollectionChanged, Sub(s, e)
				Me.UpdateProgress()
			End Sub
		End Sub
		Public Property Stages() As ObservableCollection(Of ProjectStage)
		Public Overrides Sub UpdateProgress()
			Dim completed As Integer = 0, sum As Integer = 0

			If Stages IsNot Nothing Then
				For Each stage As ProjectStage In Stages
					sum += 1
					If stage.Progress >= 100 Then
						completed += 1
					End If
				Next stage
			End If
			If sum = 0 Then
				Progress = 100
			Else
				Progress = completed * 100 \ sum
			End If
		End Sub
	End Class

	Public Class ProjectStage
		Inherits ProgressingObject

		Public Sub New()
			Tasks = New ObservableCollection(Of Task)()
			AddHandler Tasks.CollectionChanged, Sub(s, e)
				Me.UpdateProgress()
			End Sub
		End Sub

		Public Overrides Sub UpdateProgress()
			Dim completed As Integer = 0, sum As Integer = 0

			If Tasks IsNot Nothing Then
				For Each task As Task In Tasks
					sum += 1
					If task.State Is Nothing OrElse task.State.StateValue = 2 Then
						completed += 1
					End If
				Next task
			End If
			If sum = 0 Then
				Progress = 100
			Else
				Progress = completed * 100 \ sum
			End If
		End Sub

		Public Property Tasks() As ObservableCollection(Of Task)
	End Class

	Public Class Task
		Inherits BaseObject

		Private startDateCore As DateTime
		Public Property StartDate() As DateTime
			Get
				Return startDateCore
			End Get
			Set(ByVal value As DateTime)
				If StartDate = value Then
					Return
				End If
				startDateCore = value
				OnPropertyChanged("StartDate")
			End Set
		End Property
		Private endDateCore As DateTime
		Public Property EndDate() As DateTime
			Get
				Return endDateCore
			End Get
			Set(ByVal value As DateTime)
				If EndDate = value Then
					Return
				End If
				endDateCore = value
				OnPropertyChanged("EndDate")
			End Set
		End Property
		Private stateCore As State
		Public Property State() As State
			Get
				Return stateCore
			End Get
			Set(ByVal value As State)
				If ReferenceEquals(State, value) Then
					Return
				End If
				stateCore = value
				OnPropertyChanged("State")
				If Owner IsNot Nothing Then
					Owner.UpdateProgress()
				End If
			End Set
		End Property
	End Class

	Public Class State
		Implements IComparable

		Public Property Image() As ImageSource
		Public Property TextValue() As String
		Public Property StateValue() As Integer
		Public Overrides Function ToString() As String
			Return TextValue
		End Function

		Public Function CompareTo(ByVal obj As Object) As Integer Implements IComparable.CompareTo
			Return Comparer(Of Integer).Default.Compare(StateValue, DirectCast(obj, State).StateValue)
		End Function
	End Class

	Public Class States
		Inherits List(Of State)

		Private Shared src As List(Of State)
		Public Property Image() As ImageSource
		Public Shared ReadOnly Property DataSource() As List(Of State)
			Get
				If src Is Nothing Then
					src = New List(Of State)()
					src.Add(New State() With {
						.TextValue = "Not started",
						.StateValue = 0,
						.Image = New BitmapImage(New Uri("/HierarchicalDataTemplateMode;component/Images/State_NotStarted.png", UriKind.Relative))
					})
					src.Add(New State() With {
						.TextValue = "In progress",
						.StateValue = 1,
						.Image = New BitmapImage(New Uri("/HierarchicalDataTemplateMode;component/Images/State_InProgress.png", UriKind.Relative))
					})
					src.Add(New State() With {
						.TextValue = "Completed",
						.StateValue = 2,
						.Image = New BitmapImage(New Uri("/HierarchicalDataTemplateMode;component/Images/State_Completed.png", UriKind.Relative))
					})
				End If
				Return src
			End Get
		End Property
	End Class
End Namespace