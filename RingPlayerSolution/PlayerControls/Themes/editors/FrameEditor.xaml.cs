// Copyright (c) 2015-2017 All rights reserved Christian Sack
// <author>Christian Sack</author>
// <email>christian@sack.at</email>
// <website>christian.sack.at</website>
// <created>2017-02-04</creation-date>
// <modified>2017-04-27 16:23</modify-date>

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using CsWpfBase.env.extensions;
using CsWpfBase.env.tools;
using PlayerControls.Interfaces.presentation.FrameItems;
using PlayerControls.Interfaces.presentation._base;
using PlayerControls.Themes.editors.components;
using PlayerControls.Themes._components;
using PlayerControls._sys.extensions;






namespace PlayerControls.Themes.editors
{
	/// <summary>Interaction logic for FrameEditor.xaml</summary>
	public partial class FrameEditor
	{


		#region DP Keys
		/// <summary>The <see cref="DependencyProperty" /> for the <see cref="IsLocked" /> property.</summary>
		public static readonly DependencyProperty IsLockedProperty = DependencyProperty.Register("IsLocked", typeof(bool), typeof(FrameEditor), new FrameworkPropertyMetadata
																																				{
																																					BindsTwoWayByDefault = true,
																																					//PropertyChangedCallback = (o, args) => ((FrameEditor)o).IsLockedDpChanged((bool)args.OldValue, (bool)args.NewValue),
																																					DefaultValue = true,
																																					DefaultUpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged,
																																				});
		/// <summary>The <see cref="DependencyProperty" /> for the <see cref="SelectedItemContainer" /> property.</summary>
		public static readonly DependencyProperty SelectedItemContainerProperty = DependencyProperty.Register("SelectedItemContainer", typeof(FrameItemContainer), typeof(FrameEditor), new FrameworkPropertyMetadata
																																														{
																																															BindsTwoWayByDefault = true,
																																															//PropertyChangedCallback = (o, args) => ((FrameEditor)o).SelectedItemContainerDpChanged((FrameItemContainer)args.OldValue, (FrameItemContainer)args.NewValue),
																																															DefaultValue = default(FrameItemContainer),
																																															DefaultUpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged,
																																														});

		/// <summary>The <see cref="DependencyProperty" /> for the <see cref="SelectedItemIsRoot" /> property.</summary>
		public static readonly DependencyProperty SelectedItemIsRootProperty = DependencyProperty.Register("SelectedItemIsRoot", typeof(bool), typeof(FrameEditor), new FrameworkPropertyMetadata
																																									{
																																										BindsTwoWayByDefault = true,
																																										//PropertyChangedCallback = (o, args) => ((FrameEditor)o).SelectedItemIsRootDpChanged((bool)args.OldValue, (bool)args.NewValue),
																																										DefaultValue = default(bool),
																																										DefaultUpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged,
																																									});
		/// <summary>The <see cref="DependencyProperty" /> for the <see cref="SelectedItem" /> property.</summary>
		public static readonly DependencyProperty SelectedItemProperty = DependencyProperty.Register("SelectedItem", typeof(IFrameItem), typeof(FrameEditor), new FrameworkPropertyMetadata
																																							{
																																								BindsTwoWayByDefault = true,
																																								//PropertyChangedCallback = (o, args) => ((FrameEditor) o).SelectedItemDpChanged((IFrameItem) args.OldValue, (IFrameItem) args.NewValue),
																																								DefaultValue = default(IFrameItem),
																																								DefaultUpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged,
																																							});
		#endregion




		public FrameEditor()
		{
			InitializeComponent();
			PreviewKeyDown += OnPreviewKeyDown;
		}

		/// <summary>The container of the selected item</summary>
		public FrameItemContainer SelectedItemContainer
		{
			get => (FrameItemContainer) GetValue(SelectedItemContainerProperty);
			set => SetValue(SelectedItemContainerProperty, value);
		}

		/// <summary>If true the <see cref="SelectedItem" /> is the root frame.</summary>
		public bool SelectedItemIsRoot
		{
			get => (bool) GetValue(SelectedItemIsRootProperty);
			set => SetValue(SelectedItemIsRootProperty, value);
		}

		/// <summary>The selected item inside the <see cref="System.Windows.Controls.TreeView" />.</summary>
		public IFrameItem SelectedItem
		{
			get => (IFrameItem) GetValue(SelectedItemProperty);
			set => SetValue(SelectedItemProperty, value);
		}

		/// <summary>If true no changes are allowed.</summary>
		public bool IsLocked
		{
			get => (bool) GetValue(IsLockedProperty);
			set => SetValue(IsLockedProperty, value);
		}

		public ObservableCollection<HistoryEntry> HistoryEntries { get; } = new ObservableCollection<HistoryEntry>();

		private void TreeView_OnSelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
		{
			SetSelectedItem(e.NewValue as IFrameItem);
		}

		private void OnPreviewKeyDown(object sender, KeyEventArgs keyEventArgs)
		{
			if (Keyboard.Modifiers == ModifierKeys.Control && Keyboard.IsKeyDown(Key.Z))
				UndoHistoryAction();
			else if (Keyboard.IsKeyDown(Key.Escape))
				SetSelectedItem(null as IFrameItem);
		}



		private void FramePreview_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			var container = GetFrameItemContainer_FromMousePosition();
			if (container == null)
				return;

			var isSame = container == SelectedItemContainer;
			if (!isSame)
				SetSelectedItem(container);

			if (!IsLocked && !SelectedItemIsRoot)
				FrameItemDragMoveResize.Do(container, (thickness, thickness1) =>
				{
					if (Equals(thickness, thickness1))
					{
						if (isSame)
							SetSelectedItem(null as IFrameItem);
					}
					else
					{
						DoHistoryAction("Move/Resize", () => SelectedItem.FrameItemRelativePosition = thickness1, () => SelectedItem.FrameItemRelativePosition = thickness, false);
					}
				});
			else if (isSame)
				SetSelectedItem(null as IFrameItem);



			e.Handled = true;
		}


		private void FramePreview_MouseMove(object sender, MouseEventArgs mouseEventArgs)
		{
			var iFrameItemContainer = GetFrameItemContainer_FromMousePosition();
			if (iFrameItemContainer != null)
				IsMouseOverAdorner.Apply(iFrameItemContainer);
			else
				IsMouseOverAdorner.Clear(this);
		}

		private void FramePreview_OnMouseLeave(object sender, MouseEventArgs e)
		{
			IsMouseOverAdorner.Clear(this);
		}

		private void FramePreview_OnContextMenuOpening(object sender, ContextMenuEventArgs e)
		{
			if (IsLocked || SelectedItemIsRoot)
			{
				e.Handled = true;
				return;
			}

			var container = GetFrameItemContainer_FromMousePosition();
			if (container == null)
			{
				e.Handled = true;
				return;
			}


			var contextMenu = ((FrameworkElement) sender).ContextMenu;
			if (container.DataContext is IFrameItem)
			{
				var frameItem = (IFrameItem) container.DataContext;
				contextMenu.Items.Clear();

				contextMenu.Items.Add(new MenuItem
									{
										Header = "Fullscreen",
										Command = new RelayCommand(() =>
										{
											var val = frameItem.FrameItemRelativePosition;
											DoHistoryAction("Fullscreen", () => frameItem.FrameItemRelativePosition = new Thickness(0), () => { frameItem.FrameItemRelativePosition = val; });
										})
									});
				contextMenu.Items.Add(new Separator());
				contextMenu.Items.Add(new MenuItem
									{
										Header = "In den Hintergrund",
										Command = new RelayCommand(() => { DoHistoryAction("In den Hintergrund", () => SendToBack(container), () => SendToFront(container)); })
									});
				contextMenu.Items.Add(new MenuItem
									{
										Header = "In den Vordergrund",
										Command = new RelayCommand(() => DoHistoryAction("In den Vordergrund", () => SendToFront(container), () => SendToBack(container)))
									});
			}
		}



		private void SendToBack(FrameItemContainer cont)
		{
			var containingFrame = cont.VisualParent_By_Condition<FrameItemContainer>(t => t.DataContext is IFrame, true)?.DataContext as IFrame;
			if (containingFrame == null)
				return;
			var orderedElements = containingFrame.FrameChildren.OfType<IFrameItem>().OrderBy(x => x.FrameItemZIndex).ToArray();
			var indexOf = Array.IndexOf(orderedElements, cont.DataContext);

			if (indexOf == 0)
				return;

			var temp = orderedElements[indexOf];
			orderedElements[indexOf] = orderedElements[indexOf - 1];
			orderedElements[indexOf - 1] = temp;


			for (var i = 0; i < orderedElements.Length; i++)
				orderedElements[i].FrameItemZIndex = (i + 1) * 10;
		}

		private void SendToFront(FrameItemContainer cont)
		{
			var containingFrame = cont.VisualParent_By_Condition<FrameItemContainer>(t => t.DataContext is IFrame)?.DataContext as IFrame;
			if (containingFrame == null)
				return;
			var orderedElements = containingFrame.FrameChildren.OfType<IFrameItem>().OrderBy(x => x.FrameItemZIndex).ToArray();
			var indexOf = Array.IndexOf(orderedElements, cont.DataContext);

			if (indexOf == orderedElements.Length - 1)
				return;

			var temp = orderedElements[indexOf];
			orderedElements[indexOf] = orderedElements[indexOf + 1];
			orderedElements[indexOf + 1] = temp;


			for (var i = 0; i < orderedElements.Length; i++)
				orderedElements[i].FrameItemZIndex = (i + 1) * 10;
		}





		private void UndoButtonClicked(object sender, RoutedEventArgs e)
		{
			UndoHistoryAction();
		}

		private void SaveFrameAsImageClicked(object sender, RoutedEventArgs e)
		{
			Item.ConvertTo_RenderedImage(Presenter.ActualWidth, Presenter.ActualHeight).Result.SaveAsFileDialog();
		}


		private void FrameItem_ChangeImage(object sender, RoutedEventArgs e)
		{
			var imageItem = (IFrameImage) ((FrameworkElement) sender).DataContext;
			imageItem.EditorRequestedImageChange();
		}

		private void FrameItem_StoreImage(object sender, RoutedEventArgs e)
		{
			var imageItem = (IFrameImage) ((FrameworkElement) sender).DataContext;
			imageItem.FrameItemImage.SaveAsFileDialog();
		}

		private void FrameItem_AddImage(object sender, RoutedEventArgs e)
		{
			var frame = (IFrame) ((FrameworkElement) sender).DataContext;
			var element = frame.EditorRequestedNewImage();
			if (element == null)
				return;
			var frameItems = frame.FrameChildren.OfType<IFrameItem>().ToArray();
			if (frameItems.Any())
				element.FrameItemZIndex = frameItems.Max(x => x.FrameItemZIndex) + 10;
			SetSelectedItem(element);
		}

		private void FrameItem_AddText(object sender, RoutedEventArgs e)
		{
			var frame = (IFrame) ((FrameworkElement) sender).DataContext;
			var element = frame.EditorRequestedNewText();
			if (element == null)
				return;
			var frameItems = frame.FrameChildren.OfType<IFrameItem>().ToArray();
			if (frameItems.Any())
				element.FrameItemZIndex = frameItems.Max(x => x.FrameItemZIndex) + 10;


			SetSelectedItem(element);
		}

		private void FrameItem_AddVideo(object sender, RoutedEventArgs e)
		{
			var frame = (IFrame) ((FrameworkElement) sender).DataContext;
			var element = frame.EditorRequestedNewVideo();
			if (element == null)
				return;
			var frameItems = frame.FrameChildren.OfType<IFrameItem>().ToArray();
			if (frameItems.Any())
				element.FrameItemZIndex = frameItems.Max(x => x.FrameItemZIndex) + 10;


			SetSelectedItem(element);
		}

		private void FrameItem_AddFrame(object sender, RoutedEventArgs e)
		{
			var frame = (IFrame) ((FrameworkElement) sender).DataContext;
			var element = frame.EditorRequestedNewFrame();
			if (element == null)
				return;
			var frameItems = frame.FrameChildren.OfType<IFrameItem>().ToArray();
			if (frameItems.Any())
				element.FrameItemZIndex = frameItems.Max(x => x.FrameItemZIndex) + 10;
			SetSelectedItem(element);
		}

		private void FrameItem_Remove(object sender, RoutedEventArgs e)
		{
			var container = SelectedItemContainer.VisualParent_By_Condition<FrameItemContainer>(c => true);
			container.GetDataContext<IFrame>().EditorRequestedRemoveChild(SelectedItem);
			SetSelectedItem(container);
		}




		private FrameItemContainer GetFrameItemContainer_FromMousePosition()
		{
			if (SelectedItemContainer != null)
			{
				if (SelectedItemContainer.IsMouseOver)
					return SelectedItemContainer;
				var position = Mouse.GetPosition(SelectedItemContainer);
				if (position.X > 0 && position.Y > 0 && SelectedItemContainer.ActualWidth > position.X && SelectedItemContainer.ActualHeight > position.Y)
					return SelectedItemContainer;
			}

			var mouseOverElement = InputHitTest(Mouse.GetPosition(this)) as FrameworkElement;
			return mouseOverElement?.VisualParent_By_Condition<FrameItemContainer>(t => true, true);
		}

		private void SetSelectedItem(FrameItemContainer container)
		{
			SelectedItem = container?.DataContext as IFrameItem;
			SelectedItemContainer = container;
			SelectedItemIsRoot = SelectedItem == Item;
			TreeView.Select(SelectedItem);

			if (SelectedItemContainer == null)
				IsSelectedAdorner.Clear(this);
			else
				IsSelectedAdorner.Apply(SelectedItemContainer);
		}

		private void SetSelectedItem(IFrameItem item)
		{
			SelectedItem = item;
			SelectedItemContainer = item == null ? null : Presenter.VisualChild_By_Condition<FrameItemContainer>(t => t.DataContext == item);
			SelectedItemIsRoot = SelectedItem == Item;
			TreeView.Select(SelectedItem);

			if (SelectedItemContainer == null)
				IsSelectedAdorner.Clear(this);
			else
				IsSelectedAdorner.Apply(SelectedItemContainer);
		}



		private void DoHistoryAction(string name, Action redoAction, Action undoAction, bool execute = true)
		{
			HistoryEntries.Add(new HistoryEntry(name, redoAction, undoAction));
			if (execute)
				redoAction();
		}

		private void UndoHistoryAction()
		{
			if (HistoryEntries.Count == 0)
				return;
			var historyEntry = HistoryEntries.Last();
			historyEntry.UndoAction();
			HistoryEntries.RemoveAt(HistoryEntries.Count - 1);
		}





		public class HistoryEntry
		{
			/// <summary>Initializes a new instance of the <see cref="T:System.Object" /> class.</summary>
			public HistoryEntry(string name, Action redoAction, Action undoAction)
			{
				Name = name;
				RedoAction = redoAction;
				UndoAction = undoAction;
			}

			public string Name { get; }
			public Action RedoAction { get; }
			public Action UndoAction { get; }
		}
	}

}