// Copyright (c) 2016 All rights reserved Christian Sack
// <author>Christian Sack</author>
// <email>christian@sack.at</email>
// <website>christian.sack.at</website>
// <date>2017-02-05</date>

using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using CsWpfBase.Ev.Objects;
using CsWpfBase.Ev.Public.Extensions;
using CsWpfBase.Themes.Controls.Containers;
using PlayerControls.Interfaces;
using PlayerControls.Themes.editors.components;
using PlayerControls.Themes._components;






namespace PlayerControls.Themes.editors
{
	/// <summary>Interaction logic for FrameEditor.xaml</summary>
	public partial class FrameEditor : ItemControl<IFrame>
	{

		public FrameEditor()
		{
			InitializeComponent();
			PreviewKeyDown += OnPreviewKeyDown;
		}

		public ObservableCollection<HistoryEntry> HistoryEntries { get; } = new ObservableCollection<HistoryEntry>();

		private void OnPreviewKeyDown(object sender, KeyEventArgs keyEventArgs)
		{
			if (Keyboard.Modifiers == ModifierKeys.Control && Keyboard.IsKeyDown(Key.Z))
				UndoHistoryAction();
			else if (Keyboard.IsKeyDown(Key.Escape))
			{
				IsSelectedAdorner.Clear(this);
			}
		}



		private void FramePreview_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			var container = GetFrameItemContainer_FromMousePosition();
			if (container == null)
				return;
			var frameItem = (IFrameItem) container.DataContext;

			TreeView.Select(frameItem);
			IsSelectedAdorner.Apply(container);

			FrameItemDragMoveResize.Do(container, (thickness, thickness1) =>DoHistoryAction("Move/Resize", () => frameItem.FrameItemRelativePosition = thickness1, () => frameItem.FrameItemRelativePosition = thickness, false)
			);

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

		private void TreeView_OnSelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
		{
			var dataContext = e.NewValue as IFrameItem;
			if (dataContext == null)
				return;
			var frameItemContainerByItem = GetFrameItemContainer_ByItem(dataContext);
			IsSelectedAdorner.Apply(frameItemContainerByItem);
		}

		private void FramePreview_OnMouseLeave(object sender, MouseEventArgs e)
		{
			IsMouseOverAdorner.Clear(this);
		}

		private void FramePreview_OnContextMenuOpening(object sender, ContextMenuEventArgs e)
		{
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
			var containingFrame = cont.GetVisualParentByCondition<FrameItemContainer>(t => t.DataContext is IFrame)?.DataContext as IFrame;
			if (containingFrame == null)
				return;
			var orderedElements = containingFrame.FrameChildren.OrderBy(x => x.FrameItemZIndex).ToArray();
			var indexOf = Array.IndexOf(orderedElements, cont.DataContext);

			if (indexOf == 0)
				return;

			var temp = orderedElements[indexOf];
			orderedElements[indexOf] = orderedElements[indexOf - 1];
			orderedElements[indexOf - 1] = temp;


			for (var i = 0; i < orderedElements.Length; i++)
			{
				orderedElements[i].FrameItemZIndex = (i + 1) * 10;
			}
		}

		private void SendToFront(FrameItemContainer cont)
		{
			var containingFrame = cont.GetVisualParentByCondition<FrameItemContainer>(t => t.DataContext is IFrame)?.DataContext as IFrame;
			if (containingFrame == null)
				return;
			var orderedElements = containingFrame.FrameChildren.OrderBy(x => x.FrameItemZIndex).ToArray();
			var indexOf = Array.IndexOf(orderedElements, cont.DataContext);

			if (indexOf == orderedElements.Length - 1)
				return;

			var temp = orderedElements[indexOf];
			orderedElements[indexOf] = orderedElements[indexOf + 1];
			orderedElements[indexOf + 1] = temp;


			for (var i = 0; i < orderedElements.Length; i++)
			{
				orderedElements[i].FrameItemZIndex = (i + 1) * 10;
			}
		}




		private FrameItemContainer GetFrameItemContainer_FromMousePosition()
		{
			var mouseOverElement = InputHitTest(Mouse.GetPosition(this)) as FrameworkElement;
			if (mouseOverElement is FrameItemContainer)
				return (FrameItemContainer) mouseOverElement;
			return mouseOverElement?.GetVisualParentByCondition<FrameItemContainer>(t => true);
		}

		private FrameItemContainer GetFrameItemContainer_ByItem(IFrameItem item)
		{
			return Presenter.GetVisualChildByCondition<FrameItemContainer>(t => t.DataContext == item);
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



		private void UndoButtonClicked(object sender, RoutedEventArgs e)
		{
			UndoHistoryAction();
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