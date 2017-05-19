# MUINetPlus

## 框架介绍
[MUINetPlus](https://github.com/MrocCyen/MUINetPlus)是WPF的一个插件式的开发框架，界面库基于FirstFloor.ModernUI，可根据配置文件动态配置界面与功能。

相比UIShell.iOpenWorks.WPF，增加了可在不同Dll中配置同一菜单下的子菜单项，并且可自定义排序。

## 配置文件

```
<Plugin  Name="MainConfig" Author="mroccyen" Version="1.0.0" Description="" Initialized="true">
  <Extension Type="LinkGroup"  Assembly="MUINetPlus.MainPlugin.dll">
    <LinkGroup Name="Project" Index="1" DisplayName="项目" >
      <Link Name="Setting" Index="0" DisplayName="设定" Source="MUINetPlus.MainPlugin.TestUserControl"></Link>
      <Link Name="New" Index="1" DisplayName="新建" Source="MUINetPlus.MainPlugin.TestUserControl1"></Link>
    </LinkGroup>
    <LinkGroup Name="Debug" Index="0" DisplayName="调试" >
      <Link Name="Produce" Index="0" DisplayName="生成" Source="MUINetPlus.MainPlugin.TestUserControl2"></Link>
      <Link Name="Start" Index="1" DisplayName="开始" Source="MUINetPlus.MainPlugin.TestUserControl3"></Link>
    </LinkGroup>
    <LinkGroup Name="View" Index="2" DisplayName="视图" >
      <Link Name="Design" Index="0" DisplayName="设计器" Source="MUINetPlus.MainPlugin.TestUserControl6"></Link>
      <Link Name="Property" Index="1" DisplayName="属性" Source="MUINetPlus.MainPlugin.TestUserControl7"></Link>
    </LinkGroup>
    <LinkGroup Name="View" Index="2" DisplayName="视图" >
      <Link Name="Design" Index="0" DisplayName="视图1" Source="MUINetPlus.MainPlugin.TestUserControl6"></Link>
      <Link Name="Property" Index="1" DisplayName="视图2" Source="MUINetPlus.MainPlugin.TestUserControl7"></Link>
    </LinkGroup>
    <LinkGroup Name="Set" Index="2" DisplayName="设置" GroupKey="Settings" IsTitleLink="true">
      <Link Name="Set1" Index="0" DisplayName="设置1" Source="MUINetPlus.MainPlugin.TestUserControl4"></Link>
      <Link Name="Set2" Index="1" DisplayName="设置2" Source="MUINetPlus.MainPlugin.TestUserControl5"></Link>
    </LinkGroup>
    <LinkGroup Name="Color" Index="1" DisplayName="颜色" GroupKey="Settings" IsTitleLink="true">
      <Link Name="Color1" Index="0" DisplayName="颜色1" Source="MUINetPlus.MainPlugin.TestUserControl4"></Link>
      <Link Name="Color2" Index="1" DisplayName="颜色2" Source="MUINetPlus.MainPlugin.TestUserControl5"></Link>
    </LinkGroup>
  </Extension>
</Plugin>
```

每个节点的解释：

- Extension：插件的扩展节点，里面可包含一个或者多个插件项。
- LinkGroup：第一级菜单项，可以根据Index属性设置顺序优先级。
- Link：LinkGroup下的子菜单，同样可根据Index属性设置顺序优先级，同时Source设置显示的页面。

## 使用方法
只需要将相应的Dll和配置文件所在文件夹放在Plugins目录下即可。


### 意见
如果有什么意见和建议欢迎给我发邮件，大家一起探讨探讨。
