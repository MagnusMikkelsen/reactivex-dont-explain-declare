<Query Kind="Statements">
  <NuGetReference>System.Reactive.Linq</NuGetReference>
  <Namespace>LINQPad.Controls</Namespace>
  <Namespace>System.Reactive.Linq</Namespace>
  <Namespace>System.Reactive.Subjects</Namespace>
</Query>


#region textbox
var textbox = new TextBox();
textbox.Dump();

var whenTextInput = Observable.FromEventPattern<EventHandler, EventArgs>(
	h => textbox.TextInput += h,
	h => textbox.TextInput -= h)
	.Select(_ => textbox.Text);
#endregion	

whenTextInput
	
	//.Throttle(TimeSpan.FromMilliseconds(500))	
	//.DistinctUntilChanged()
	
	.Dump();