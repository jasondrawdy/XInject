# XInject
XInject is a minimalistic and user-friendly tool to inject Win32 compatible icons into .NET assemblies. It is originally based off of the InsertIcons project started by Einar Egilsson @ https://github.com/einaregilsson/InsertIcons.

<b>Note</b> - <i>XInject is retina ready and looks crisp at most resolutions!</i>

# Requirements
 - Windows 7 SP1 & Higher
 - .NET Framework 4.6.1

# References

<h3>ObjectListView</h3>
XInject utilizes a customized ListView called ObjectListView which can be found at http://objectlistview.sourceforge.net/cs/index.html

<h3><u> Embedded Assembly </u></h3>
ObjectListView has been embedded within the XInject assembly and thus an extra step will be needed in order to compile the project. First, download and reference <i>ObjectListView.dll</i> from the author's homepage above. Second, add an existing file to XInject by right-clicking on the project in the treeview and selecting the OLV DLL file. Lastly, change the <b>Build Action</b> on the added file from <i>Compile</i> to <i>Embedded Resource</i>.

# License
This program is licensed under the MIT license. It's heavily based on MIT licensed code from the great library ResourceLib, which is highly recommended and can be found at https://github.com/dblock/resourcelib. It also uses MIT licensed code from the Mono project (http://mono-project.com) for strong name signing utilizing the RSA encryption scheme.

# Screenshot
![alt tag](https://cloud.githubusercontent.com/assets/17565891/19375791/6f262ed4-919d-11e6-9cca-d9ac1cc4538e.png)
