# 虚拟手术后台的批量用户注册器 | VSBatchRegister

### 介绍

虚拟手术项目，直连数据库做的批量注册机，可用于非后台所在电脑，供老师们直接自行进行学生的批量注册。

### 操作流程

##### 配置 

在Resources\Config下，配置config.json，如果没有请创建，字段内容如下

```json
{
  "DB": "Server=127.0.0.1;Port=3306;Database={你的数据库名};User={你的用户名};Password={你的密码};"
}
```

##### 运行

打开项目后会基于配置自动链接数据库，如成功可看到数据库中用户信息

![1](Img/1.png)

点击加载Excel，可以加载教师汇总手机的注册信息登记表，推荐用腾讯文档提供的收集表导出成本地Excel文件。此时显示数据会切换为从Excel读取到的数据内容。

![2](Img/2.png)

点击导入数据库，如果成功会有提示

![3](Img/3.png)

如果遇到错误，无法链接数据库，则右上角状态栏会标红，提示连接失败

![error](Img/error.png)

### 技术栈选型

| 名字                                | 介绍           | 版本   |
| ----------------------------------- | -------------- | ------ |
| AntdUI                              | UI库           | 1.8.8  |
| log4net                             | 日志库         | 3.0.3  |
| Microsoft.EntityFrameworkCore       | EF框架核心层   | 8.0.11 |
| Microsoft.EntityFrameworkCore.Tools | EF框架工具层   | 8.0.11 |
| MySql.Data                          | MYSQL链接      | 9.2    |
| Pomelo.EntityFrameworkCore.MySql    | EF-MYSQL中间层 | 2.7.2  |
| NPOI                                | Excel交互库    | 8.0.2  |

注意，EF-Mysql由第三方提供，其只支持 到8.0.x版本，但是EF框架最新版本已经到9.x版本了，两边版本不同步会无法安装，因此EF框架使用8.0.11，其余库关联性不大

### QA：

1. 为啥不直接用腾讯文档的自动化解决	A: 安全问题，内网项目