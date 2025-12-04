using System;
using Eto.Forms;
using Eto.Drawing;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.InteropServices;

namespace DataStructuresToolkit.UI
{
	public partial class MainForm : Form
	{
		public MainForm()
		{
			Title = "Data Structures Toolkit Demo UI";
			MinimumSize = new Size(1280, 720);
			
			Label deflabel = new();
			string defaultFont = deflabel.Font.FamilyName;
			float defaultFontSize = 16.0f;
			
			Eto.Style.Add<TextControl>("h1", text => text.Font = new Font(defaultFont, defaultFontSize * 2.00f, FontStyle.Bold));
			Eto.Style.Add<TextControl>("h2", text => text.Font = new Font(defaultFont, defaultFontSize * 1.50f, FontStyle.Bold));
			Eto.Style.Add<TextControl>("h3", text => text.Font = new Font(defaultFont, defaultFontSize * 1.17f, FontStyle.Bold));
			Eto.Style.Add<TextControl>("h4", text => text.Font = new Font(defaultFont, defaultFontSize * 1.00f, FontStyle.Bold));
			Eto.Style.Add<TextControl>("h5", text => text.Font = new Font(defaultFont, defaultFontSize * 0.83f, FontStyle.Bold));
			Eto.Style.Add<TextControl>("h6", text => text.Font = new Font(defaultFont, defaultFontSize * 0.67f, FontStyle.Bold));
			Eto.Style.Add<TextControl>("f-main", text =>
			{
				
				text.TextColor = BackgroundColor.ToHSL().L < 0.5 ? new Color(1, 1, 1, 1) : new Color(0, 0, 0, 1);
			});
			Eto.Style.Add<Label>("center", text =>
			{
				text.VerticalAlignment = VerticalAlignment.Center;
				text.TextAlignment = TextAlignment.Center;
			});

			Control homeLayout = new TableLayout
			{
				Width = MinimumSize.Width - 20,
				Padding = 10,
				Rows =
				{
					new TableRow
					(
						null,
						new Label{Style = "h1 center ", Text = "Home"},
						null
					),
					new TableRow
					(
						null,
						new Label{Style = "", Text = "Welcome to the Data Structures Toolkit UI Demo!\nThe entire purpose of this is to act as a ui to showcase the libraries features without relying on a terminal.\n\nYou can find the demo by clicking on the items above, or by clicking the Demo menu item.\nEach demo matches the subject of each week that is included in the project. Certain weeks are missing, so they don't have demos."},
						null
					),
					new TableRow(
						null,
						new Label{Style = "h4 center ", Text = "Week 3 ---- Stack and Queue Demo\nWeek 5 ---- Sorting and Searching Demo\nWeek 8 ---- Dictionary and HashSet Demo\nWeek 10 ---- Graph and HashSet vs. List Demo"},
						null
					)
				}
			};

			Content = homeLayout;


#region Commands
			Command quitCommand = new Command { MenuText = "Quit", Shortcut = Application.Instance.CommonModifier | Keys.Q };
			quitCommand.Executed += (sender, e) => Application.Instance.Quit();

			Command aboutCommand = new Command { MenuText = "About..." };
			aboutCommand.Executed += (sender, e) => new AboutDialog().ShowDialog(this);

			Command homeCommand = new Command { MenuText = "Home", ToolBarText = "Home" };
			homeCommand.Executed += (sender, e) => Content = homeLayout;

			// Demo Commands

			Command stackDemoCommand = new Command { MenuText = "Stack Demo", ToolBarText = "Stack Demo" };
			stackDemoCommand.Executed += (sender, e) => Content = Demos.GetStackDemo();
			
			Command queueDemoCommand = new Command { MenuText = "Queue Demo", ToolBarText = "Queue Demo" };
			queueDemoCommand.Executed += (sender, e) => Content = Demos.GetQueueDemo();
			
			Command sortingDemoCommand = new Command { MenuText = "Sorting Demo", ToolBarText = "Sorting Demo" };
			sortingDemoCommand.Executed += (sender, e) => Content = Demos.GetSortDemo();
			
			Command searchDemoCommand = new Command { MenuText = "Search Demo", ToolBarText = "Search Demo" };
			searchDemoCommand.Executed += (sender, e) => Content = Demos.GetSearchDemo();
			
			Command dictionaryDemoCommand = new Command { MenuText = "Dictionary Demo", ToolBarText = "Dictionary Demo" };
			dictionaryDemoCommand.Executed += (sender, e) => Content = Demos.GetDictionaryDemo();
			
			Command hashsetDemoCommand = new Command { MenuText = "HashSet Demo", ToolBarText = "HashSet Demo" };
			hashsetDemoCommand.Executed += (sender, e) => Content = Demos.GetHashSetDemo();
			
			Command graphDemoCommand = new Command { MenuText = "Graph Demo", ToolBarText = "Graph Demo" };
			graphDemoCommand.Executed += (sender, e) => Content = Demos.GetGraphDemo();
			
			Command hashsetlistDemoCommand = new Command { MenuText = "Hashset v. List Demo", ToolBarText = "Hashset v. List Demo" };
			hashsetlistDemoCommand.Executed += (sender, e) => Content = Demos.GetHashSetListDemo();

			IEnumerable<Command> demoCommands = 
				[
					homeCommand,
					stackDemoCommand, 
					queueDemoCommand, 
					sortingDemoCommand,
					searchDemoCommand,
					dictionaryDemoCommand,
					hashsetDemoCommand,
					graphDemoCommand,
					hashsetlistDemoCommand
				];
			
			SubMenuItem demoSMI = new();
			demoSMI.Text = "&Demo";
			demoSMI.Items.AddRange(demoCommands);

			ToolBar demoTool = new();
			demoTool.Items.AddRange(demoCommands);
#endregion

			// create menu
			Menu = new MenuBar
			{
				Items =
				{
					// File submenu
					new SubMenuItem { Text = "&File", Items = {  } },
					demoSMI,
				},
				ApplicationItems =
				{
					// application (OS X) or file menu (others)
					new ButtonMenuItem { Text = "&Preferences..." },
				},
				QuitItem = quitCommand,
				AboutItem = aboutCommand
			};

			// create toolbar
			ToolBar = demoTool;
		}
	}
}
