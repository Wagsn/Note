# Winform for Note

- User (SignUp and SignIn)
- Note (Add then edit, Save, Delete, Upload to cloud)

## Note Installer

生成应用程序安装器
- 创建Setup Project
- 右键安装项目，【Add】->【项目输出】
- 选择要安装的Winform项目，配置-【活动】，点击【确认】
- 点击Application Folder，创建两个Shortcut，改名为项目名分别移动到Desktop和Program Menu
- 左键安装项目，点击属性，修改Author和Manufacturer为公司或个人名（右键【Application Folder】，点击属性可以看到【DefaultLocation】）
- 接上步修改ProductName为期望名称

如何修改最后安装路径的EXE文件名
- 打开Winform项目的csproj配置文件，修改Assembly文件名
- 或者打开Winform项目的【属性】->【应用程序】，编辑程序集信息

如何修改应用程序的Logo
- 项目中，右键项目属性，【应用程序】->【图标和清单】，将ICO文件导入项目中，并选择它
- 安装项目中，先将ICO文件导入项目，右键Shortcut，修改其属性中的Ico路径