# XInject
<p align="left">
    <!-- Version -->
    <img src="https://img.shields.io/badge/version-0.0.1-brightgreen.svg">
    <!-- Docs -->
    <img src="https://img.shields.io/badge/docs-not%20found-lightgrey.svg">
    <!-- License -->
    <img src="https://img.shields.io/badge/license-MIT-blue.svg">
</p>

XInject is a minimalistic and user-friendly tool to inject Win32 compatible icons into .NET assemblies. It is originally based off of the InsertIcons project started by Einar Egilsson @ https://github.com/einaregilsson/InsertIcons.

<b>Note</b> - <i>XInject is retina ready and looks crisp at most resolutions!</i>

### Requirements
 - Windows 7 SP1 & Higher
 - .NET Framework 4.6.1

# References

### ObjectListView
XInject utilizes a customized ListView called ObjectListView which can be found [here]("http://objectlistview.sourceforge.net/cs/index.html") and is a fundamental dependency that is required in order to build the application from source.

### Embedded Assembly
ObjectListView has been embedded within the Auto Archiver assembly and thus an extra step will be needed in order to compile the project. First, download and reference *ObjectListView.dll* from the author's homepage above. Second, add an existing file to Auto Archiver by right-clicking on the project in the treeview and selecting the OLV DLL file. Lastly, change the ***`Build Action`*** on the added file from *`Compile`* to *`Embedded Resource`*.

# Screenshot
![alt tag](https://cloud.githubusercontent.com/assets/17565891/19375791/6f262ed4-919d-11e6-9cca-d9ac1cc4538e.png)

# License
This program is licensed under the MIT license. It's heavily based on MIT licensed code from the great library ResourceLib, which is highly recommended and can be found at https://github.com/dblock/resourcelib. It also uses MIT licensed code from the Mono project (http://mono-project.com) for strong name signing utilizing the RSA encryption scheme.
