using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HKW.HKWAvalonia.Dialogs;

/// <summary>
/// 对话框关闭前事件
/// </summary>
/// <typeparam name="T">发送者类型</typeparam>
/// <param name="sender">发送者</param>
/// <param name="e">可取消事件参数</param>
public delegate void DialogClosing<T>(T sender, CancelEventArgs e);
