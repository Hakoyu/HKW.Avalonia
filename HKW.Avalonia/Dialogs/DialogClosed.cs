using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HKW.HKWAvalonia.Dialogs;

/// <summary>
/// 对话框关闭后事件
/// </summary>
/// <typeparam name="T">发送者类型</typeparam>
/// <param name="sender">发送者</param>
/// <param name="e">事件参数</param>
public delegate void DialogClosed<T>(T sender, EventArgs e);
