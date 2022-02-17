/*
* MATLAB Compiler: 8.1 (R2020b)
* Date: Tue Feb 15 15:55:10 2022
* Arguments:
* "-B""macro_default""-W""dotnet:TestFun,Class1,4.0,private,version=1.0""-T""link:lib""-d"
* "D:\Workspace\Code\SolidworksCode\Matlab\MatlabOptFun\TestFun\for_testing""-v""class{Cla
* ss1:D:\Workspace\Code\SolidworksCode\Matlab\MatlabOptFun\crossFun.m,D:\Workspace\Code\So
* lidworksCode\Matlab\MatlabOptFun\inherFun.m,D:\Workspace\Code\SolidworksCode\Matlab\Matl
* abOptFun\mutatePopu.m,D:\Workspace\Code\SolidworksCode\Matlab\MatlabOptFun\optFun.m,D:\W
* orkspace\Code\SolidworksCode\Matlab\MatlabOptFun\selePopu.m}"
*/
using System;
using System.Reflection;
using System.IO;
using MathWorks.MATLAB.NET.Arrays;
using MathWorks.MATLAB.NET.Utility;

#if SHARED
[assembly: System.Reflection.AssemblyKeyFile(@"")]
#endif

namespace TestFunNative
{

  /// <summary>
  /// The Class1 class provides a CLS compliant, Object (native) interface to the MATLAB
  /// functions contained in the files:
  /// <newpara></newpara>
  /// D:\Workspace\Code\SolidworksCode\Matlab\MatlabOptFun\crossFun.m
  /// <newpara></newpara>
  /// D:\Workspace\Code\SolidworksCode\Matlab\MatlabOptFun\inherFun.m
  /// <newpara></newpara>
  /// D:\Workspace\Code\SolidworksCode\Matlab\MatlabOptFun\mutatePopu.m
  /// <newpara></newpara>
  /// D:\Workspace\Code\SolidworksCode\Matlab\MatlabOptFun\optFun.m
  /// <newpara></newpara>
  /// D:\Workspace\Code\SolidworksCode\Matlab\MatlabOptFun\selePopu.m
  /// </summary>
  /// <remarks>
  /// @Version 1.0
  /// </remarks>
  public class Class1 : IDisposable
  {
    #region Constructors

    /// <summary internal= "true">
    /// The static constructor instantiates and initializes the MATLAB Runtime instance.
    /// </summary>
    static Class1()
    {
      if (MWMCR.MCRAppInitialized)
      {
        try
        {
          Assembly assembly= Assembly.GetExecutingAssembly();

          string ctfFilePath= assembly.Location;

		  int lastDelimiter = ctfFilePath.LastIndexOf(@"/");

	      if (lastDelimiter == -1)
		  {
		    lastDelimiter = ctfFilePath.LastIndexOf(@"\");
		  }

          ctfFilePath= ctfFilePath.Remove(lastDelimiter, (ctfFilePath.Length - lastDelimiter));

          string ctfFileName = "TestFun.ctf";

          Stream embeddedCtfStream = null;

          String[] resourceStrings = assembly.GetManifestResourceNames();

          foreach (String name in resourceStrings)
          {
            if (name.Contains(ctfFileName))
            {
              embeddedCtfStream = assembly.GetManifestResourceStream(name);
              break;
            }
          }
          mcr= new MWMCR("",
                         ctfFilePath, embeddedCtfStream, true);
        }
        catch(Exception ex)
        {
          ex_ = new Exception("MWArray assembly failed to be initialized", ex);
        }
      }
      else
      {
        ex_ = new ApplicationException("MWArray assembly could not be initialized");
      }
    }


    /// <summary>
    /// Constructs a new instance of the Class1 class.
    /// </summary>
    public Class1()
    {
      if(ex_ != null)
      {
        throw ex_;
      }
    }


    #endregion Constructors

    #region Finalize

    /// <summary internal= "true">
    /// Class destructor called by the CLR garbage collector.
    /// </summary>
    ~Class1()
    {
      Dispose(false);
    }


    /// <summary>
    /// Frees the native resources associated with this object
    /// </summary>
    public void Dispose()
    {
      Dispose(true);

      GC.SuppressFinalize(this);
    }


    /// <summary internal= "true">
    /// Internal dispose function
    /// </summary>
    protected virtual void Dispose(bool disposing)
    {
      if (!disposed)
      {
        disposed= true;

        if (disposing)
        {
          // Free managed resources;
        }

        // Free native resources
      }
    }


    #endregion Finalize

    #region Methods

    /// <summary>
    /// Provides a single output, 0-input Objectinterface to the crossFun MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// 定义两个数组
    /// </remarks>
    /// <returns>An Object containing the first output argument.</returns>
    ///
    public Object crossFun()
    {
      return mcr.EvaluateFunction("crossFun", new Object[]{});
    }


    /// <summary>
    /// Provides a single output, 1-input Objectinterface to the crossFun MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// 定义两个数组
    /// </remarks>
    /// <param name="len1">Input argument #1</param>
    /// <returns>An Object containing the first output argument.</returns>
    ///
    public Object crossFun(Object len1)
    {
      return mcr.EvaluateFunction("crossFun", len1);
    }


    /// <summary>
    /// Provides a single output, 2-input Objectinterface to the crossFun MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// 定义两个数组
    /// </remarks>
    /// <param name="len1">Input argument #1</param>
    /// <param name="len2">Input argument #2</param>
    /// <returns>An Object containing the first output argument.</returns>
    ///
    public Object crossFun(Object len1, Object len2)
    {
      return mcr.EvaluateFunction("crossFun", len1, len2);
    }


    /// <summary>
    /// Provides the standard 0-input Object interface to the crossFun MATLAB function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// 定义两个数组
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public Object[] crossFun(int numArgsOut)
    {
      return mcr.EvaluateFunction(numArgsOut, "crossFun", new Object[]{});
    }


    /// <summary>
    /// Provides the standard 1-input Object interface to the crossFun MATLAB function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// 定义两个数组
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="len1">Input argument #1</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public Object[] crossFun(int numArgsOut, Object len1)
    {
      return mcr.EvaluateFunction(numArgsOut, "crossFun", len1);
    }


    /// <summary>
    /// Provides the standard 2-input Object interface to the crossFun MATLAB function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// 定义两个数组
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="len1">Input argument #1</param>
    /// <param name="len2">Input argument #2</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public Object[] crossFun(int numArgsOut, Object len1, Object len2)
    {
      return mcr.EvaluateFunction(numArgsOut, "crossFun", len1, len2);
    }


    /// <summary>
    /// Provides an interface for the crossFun function in which the input and output
    /// arguments are specified as an array of Objects.
    /// </summary>
    /// <remarks>
    /// This method will allocate and return by reference the output argument
    /// array.<newpara></newpara>
    /// M-Documentation:
    /// 定义两个数组
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return</param>
    /// <param name= "argsOut">Array of Object output arguments</param>
    /// <param name= "argsIn">Array of Object input arguments</param>
    /// <param name= "varArgsIn">Array of Object representing variable input
    /// arguments</param>
    ///
    [MATLABSignature("crossFun", 2, 3, 0)]
    protected void crossFun(int numArgsOut, ref Object[] argsOut, Object[] argsIn, params Object[] varArgsIn)
    {
        mcr.EvaluateFunctionForTypeSafeCall("crossFun", numArgsOut, ref argsOut, argsIn, varArgsIn);
    }
    /// <summary>
    /// Provides a single output, 0-input Objectinterface to the inherFun MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// 初始化结构体
    /// </remarks>
    /// <returns>An Object containing the first output argument.</returns>
    ///
    public Object inherFun()
    {
      return mcr.EvaluateFunction("inherFun", new Object[]{});
    }


    /// <summary>
    /// Provides a single output, 1-input Objectinterface to the inherFun MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// 初始化结构体
    /// </remarks>
    /// <param name="inL1">Input argument #1</param>
    /// <returns>An Object containing the first output argument.</returns>
    ///
    public Object inherFun(Object inL1)
    {
      return mcr.EvaluateFunction("inherFun", inL1);
    }


    /// <summary>
    /// Provides a single output, 2-input Objectinterface to the inherFun MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// 初始化结构体
    /// </remarks>
    /// <param name="inL1">Input argument #1</param>
    /// <param name="inL2">Input argument #2</param>
    /// <returns>An Object containing the first output argument.</returns>
    ///
    public Object inherFun(Object inL1, Object inL2)
    {
      return mcr.EvaluateFunction("inherFun", inL1, inL2);
    }


    /// <summary>
    /// Provides a single output, 3-input Objectinterface to the inherFun MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// 初始化结构体
    /// </remarks>
    /// <param name="inL1">Input argument #1</param>
    /// <param name="inL2">Input argument #2</param>
    /// <param name="inL3">Input argument #3</param>
    /// <returns>An Object containing the first output argument.</returns>
    ///
    public Object inherFun(Object inL1, Object inL2, Object inL3)
    {
      return mcr.EvaluateFunction("inherFun", inL1, inL2, inL3);
    }


    /// <summary>
    /// Provides the standard 0-input Object interface to the inherFun MATLAB function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// 初始化结构体
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public Object[] inherFun(int numArgsOut)
    {
      return mcr.EvaluateFunction(numArgsOut, "inherFun", new Object[]{});
    }


    /// <summary>
    /// Provides the standard 1-input Object interface to the inherFun MATLAB function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// 初始化结构体
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="inL1">Input argument #1</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public Object[] inherFun(int numArgsOut, Object inL1)
    {
      return mcr.EvaluateFunction(numArgsOut, "inherFun", inL1);
    }


    /// <summary>
    /// Provides the standard 2-input Object interface to the inherFun MATLAB function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// 初始化结构体
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="inL1">Input argument #1</param>
    /// <param name="inL2">Input argument #2</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public Object[] inherFun(int numArgsOut, Object inL1, Object inL2)
    {
      return mcr.EvaluateFunction(numArgsOut, "inherFun", inL1, inL2);
    }


    /// <summary>
    /// Provides the standard 3-input Object interface to the inherFun MATLAB function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// 初始化结构体
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="inL1">Input argument #1</param>
    /// <param name="inL2">Input argument #2</param>
    /// <param name="inL3">Input argument #3</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public Object[] inherFun(int numArgsOut, Object inL1, Object inL2, Object inL3)
    {
      return mcr.EvaluateFunction(numArgsOut, "inherFun", inL1, inL2, inL3);
    }


    /// <summary>
    /// Provides an interface for the inherFun function in which the input and output
    /// arguments are specified as an array of Objects.
    /// </summary>
    /// <remarks>
    /// This method will allocate and return by reference the output argument
    /// array.<newpara></newpara>
    /// M-Documentation:
    /// 初始化结构体
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return</param>
    /// <param name= "argsOut">Array of Object output arguments</param>
    /// <param name= "argsIn">Array of Object input arguments</param>
    /// <param name= "varArgsIn">Array of Object representing variable input
    /// arguments</param>
    ///
    [MATLABSignature("inherFun", 3, 3, 0)]
    protected void inherFun(int numArgsOut, ref Object[] argsOut, Object[] argsIn, params Object[] varArgsIn)
    {
        mcr.EvaluateFunctionForTypeSafeCall("inherFun", numArgsOut, ref argsOut, argsIn, varArgsIn);
    }
    /// <summary>
    /// Provides a single output, 0-input Objectinterface to the mutatePopu MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// 没有什么好的算法，就干脆让机械臂重新生成一个新的长度数�
    /// ��
    /// </remarks>
    /// <returns>An Object containing the first output argument.</returns>
    ///
    public Object mutatePopu()
    {
      return mcr.EvaluateFunction("mutatePopu", new Object[]{});
    }


    /// <summary>
    /// Provides a single output, 1-input Objectinterface to the mutatePopu MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// 没有什么好的算法，就干脆让机械臂重新生成一个新的长度数�
    /// ��
    /// </remarks>
    /// <param name="len">Input argument #1</param>
    /// <returns>An Object containing the first output argument.</returns>
    ///
    public Object mutatePopu(Object len)
    {
      return mcr.EvaluateFunction("mutatePopu", len);
    }


    /// <summary>
    /// Provides a single output, 2-input Objectinterface to the mutatePopu MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// 没有什么好的算法，就干脆让机械臂重新生成一个新的长度数�
    /// ��
    /// </remarks>
    /// <param name="len">Input argument #1</param>
    /// <param name="nMuta">Input argument #2</param>
    /// <returns>An Object containing the first output argument.</returns>
    ///
    public Object mutatePopu(Object len, Object nMuta)
    {
      return mcr.EvaluateFunction("mutatePopu", len, nMuta);
    }


    /// <summary>
    /// Provides a single output, 3-input Objectinterface to the mutatePopu MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// 没有什么好的算法，就干脆让机械臂重新生成一个新的长度数�
    /// ��
    /// </remarks>
    /// <param name="len">Input argument #1</param>
    /// <param name="nMuta">Input argument #2</param>
    /// <param name="sumLen">Input argument #3</param>
    /// <returns>An Object containing the first output argument.</returns>
    ///
    public Object mutatePopu(Object len, Object nMuta, Object sumLen)
    {
      return mcr.EvaluateFunction("mutatePopu", len, nMuta, sumLen);
    }


    /// <summary>
    /// Provides the standard 0-input Object interface to the mutatePopu MATLAB function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// 没有什么好的算法，就干脆让机械臂重新生成一个新的长度数�
    /// ��
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public Object[] mutatePopu(int numArgsOut)
    {
      return mcr.EvaluateFunction(numArgsOut, "mutatePopu", new Object[]{});
    }


    /// <summary>
    /// Provides the standard 1-input Object interface to the mutatePopu MATLAB function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// 没有什么好的算法，就干脆让机械臂重新生成一个新的长度数�
    /// ��
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="len">Input argument #1</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public Object[] mutatePopu(int numArgsOut, Object len)
    {
      return mcr.EvaluateFunction(numArgsOut, "mutatePopu", len);
    }


    /// <summary>
    /// Provides the standard 2-input Object interface to the mutatePopu MATLAB function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// 没有什么好的算法，就干脆让机械臂重新生成一个新的长度数�
    /// ��
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="len">Input argument #1</param>
    /// <param name="nMuta">Input argument #2</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public Object[] mutatePopu(int numArgsOut, Object len, Object nMuta)
    {
      return mcr.EvaluateFunction(numArgsOut, "mutatePopu", len, nMuta);
    }


    /// <summary>
    /// Provides the standard 3-input Object interface to the mutatePopu MATLAB function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// 没有什么好的算法，就干脆让机械臂重新生成一个新的长度数�
    /// ��
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="len">Input argument #1</param>
    /// <param name="nMuta">Input argument #2</param>
    /// <param name="sumLen">Input argument #3</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public Object[] mutatePopu(int numArgsOut, Object len, Object nMuta, Object sumLen)
    {
      return mcr.EvaluateFunction(numArgsOut, "mutatePopu", len, nMuta, sumLen);
    }


    /// <summary>
    /// Provides an interface for the mutatePopu function in which the input and output
    /// arguments are specified as an array of Objects.
    /// </summary>
    /// <remarks>
    /// This method will allocate and return by reference the output argument
    /// array.<newpara></newpara>
    /// M-Documentation:
    /// 没有什么好的算法，就干脆让机械臂重新生成一个新的长度数�
    /// ��
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return</param>
    /// <param name= "argsOut">Array of Object output arguments</param>
    /// <param name= "argsIn">Array of Object input arguments</param>
    /// <param name= "varArgsIn">Array of Object representing variable input
    /// arguments</param>
    ///
    [MATLABSignature("mutatePopu", 3, 1, 0)]
    protected void mutatePopu(int numArgsOut, ref Object[] argsOut, Object[] argsIn, params Object[] varArgsIn)
    {
        mcr.EvaluateFunctionForTypeSafeCall("mutatePopu", numArgsOut, ref argsOut, argsIn, varArgsIn);
    }
    /// <summary>
    /// Provides a single output, 0-input Objectinterface to the optFun MATLAB function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// 建立机器人模型
    /// theta    d        a        alpha     offset
    /// </remarks>
    /// <returns>An Object containing the first output argument.</returns>
    ///
    public Object optFun()
    {
      return mcr.EvaluateFunction("optFun", new Object[]{});
    }


    /// <summary>
    /// Provides a single output, 1-input Objectinterface to the optFun MATLAB function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// 建立机器人模型
    /// theta    d        a        alpha     offset
    /// </remarks>
    /// <param name="inL">Input argument #1</param>
    /// <returns>An Object containing the first output argument.</returns>
    ///
    public Object optFun(Object inL)
    {
      return mcr.EvaluateFunction("optFun", inL);
    }


    /// <summary>
    /// Provides a single output, 2-input Objectinterface to the optFun MATLAB function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// 建立机器人模型
    /// theta    d        a        alpha     offset
    /// </remarks>
    /// <param name="inL">Input argument #1</param>
    /// <param name="Posture">Input argument #2</param>
    /// <returns>An Object containing the first output argument.</returns>
    ///
    public Object optFun(Object inL, Object Posture)
    {
      return mcr.EvaluateFunction("optFun", inL, Posture);
    }


    /// <summary>
    /// Provides a single output, 3-input Objectinterface to the optFun MATLAB function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// 建立机器人模型
    /// theta    d        a        alpha     offset
    /// </remarks>
    /// <param name="inL">Input argument #1</param>
    /// <param name="Posture">Input argument #2</param>
    /// <param name="Arr">Input argument #3</param>
    /// <returns>An Object containing the first output argument.</returns>
    ///
    public Object optFun(Object inL, Object Posture, Object Arr)
    {
      return mcr.EvaluateFunction("optFun", inL, Posture, Arr);
    }


    /// <summary>
    /// Provides a single output, 4-input Objectinterface to the optFun MATLAB function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// 建立机器人模型
    /// theta    d        a        alpha     offset
    /// </remarks>
    /// <param name="inL">Input argument #1</param>
    /// <param name="Posture">Input argument #2</param>
    /// <param name="Arr">Input argument #3</param>
    /// <param name="posLen">Input argument #4</param>
    /// <returns>An Object containing the first output argument.</returns>
    ///
    public Object optFun(Object inL, Object Posture, Object Arr, Object posLen)
    {
      return mcr.EvaluateFunction("optFun", inL, Posture, Arr, posLen);
    }


    /// <summary>
    /// Provides the standard 0-input Object interface to the optFun MATLAB function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// 建立机器人模型
    /// theta    d        a        alpha     offset
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public Object[] optFun(int numArgsOut)
    {
      return mcr.EvaluateFunction(numArgsOut, "optFun", new Object[]{});
    }


    /// <summary>
    /// Provides the standard 1-input Object interface to the optFun MATLAB function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// 建立机器人模型
    /// theta    d        a        alpha     offset
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="inL">Input argument #1</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public Object[] optFun(int numArgsOut, Object inL)
    {
      return mcr.EvaluateFunction(numArgsOut, "optFun", inL);
    }


    /// <summary>
    /// Provides the standard 2-input Object interface to the optFun MATLAB function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// 建立机器人模型
    /// theta    d        a        alpha     offset
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="inL">Input argument #1</param>
    /// <param name="Posture">Input argument #2</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public Object[] optFun(int numArgsOut, Object inL, Object Posture)
    {
      return mcr.EvaluateFunction(numArgsOut, "optFun", inL, Posture);
    }


    /// <summary>
    /// Provides the standard 3-input Object interface to the optFun MATLAB function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// 建立机器人模型
    /// theta    d        a        alpha     offset
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="inL">Input argument #1</param>
    /// <param name="Posture">Input argument #2</param>
    /// <param name="Arr">Input argument #3</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public Object[] optFun(int numArgsOut, Object inL, Object Posture, Object Arr)
    {
      return mcr.EvaluateFunction(numArgsOut, "optFun", inL, Posture, Arr);
    }


    /// <summary>
    /// Provides the standard 4-input Object interface to the optFun MATLAB function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// 建立机器人模型
    /// theta    d        a        alpha     offset
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="inL">Input argument #1</param>
    /// <param name="Posture">Input argument #2</param>
    /// <param name="Arr">Input argument #3</param>
    /// <param name="posLen">Input argument #4</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public Object[] optFun(int numArgsOut, Object inL, Object Posture, Object Arr, Object 
                     posLen)
    {
      return mcr.EvaluateFunction(numArgsOut, "optFun", inL, Posture, Arr, posLen);
    }


    /// <summary>
    /// Provides an interface for the optFun function in which the input and output
    /// arguments are specified as an array of Objects.
    /// </summary>
    /// <remarks>
    /// This method will allocate and return by reference the output argument
    /// array.<newpara></newpara>
    /// M-Documentation:
    /// 建立机器人模型
    /// theta    d        a        alpha     offset
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return</param>
    /// <param name= "argsOut">Array of Object output arguments</param>
    /// <param name= "argsIn">Array of Object input arguments</param>
    /// <param name= "varArgsIn">Array of Object representing variable input
    /// arguments</param>
    ///
    [MATLABSignature("optFun", 4, 1, 0)]
    protected void optFun(int numArgsOut, ref Object[] argsOut, Object[] argsIn, params Object[] varArgsIn)
    {
        mcr.EvaluateFunctionForTypeSafeCall("optFun", numArgsOut, ref argsOut, argsIn, varArgsIn);
    }
    /// <summary>
    /// Provides a single output, 0-input Objectinterface to the selePopu MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// 锦标赛选择法（随便选两个标签，看谁的amt比较好就选谁）
    /// </remarks>
    /// <returns>An Object containing the first output argument.</returns>
    ///
    public Object selePopu()
    {
      return mcr.EvaluateFunction("selePopu", new Object[]{});
    }


    /// <summary>
    /// Provides a single output, 1-input Objectinterface to the selePopu MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// 锦标赛选择法（随便选两个标签，看谁的amt比较好就选谁）
    /// </remarks>
    /// <param name="Parent">Input argument #1</param>
    /// <returns>An Object containing the first output argument.</returns>
    ///
    public Object selePopu(Object Parent)
    {
      return mcr.EvaluateFunction("selePopu", Parent);
    }


    /// <summary>
    /// Provides the standard 0-input Object interface to the selePopu MATLAB function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// 锦标赛选择法（随便选两个标签，看谁的amt比较好就选谁）
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public Object[] selePopu(int numArgsOut)
    {
      return mcr.EvaluateFunction(numArgsOut, "selePopu", new Object[]{});
    }


    /// <summary>
    /// Provides the standard 1-input Object interface to the selePopu MATLAB function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// 锦标赛选择法（随便选两个标签，看谁的amt比较好就选谁）
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="Parent">Input argument #1</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public Object[] selePopu(int numArgsOut, Object Parent)
    {
      return mcr.EvaluateFunction(numArgsOut, "selePopu", Parent);
    }


    /// <summary>
    /// Provides an interface for the selePopu function in which the input and output
    /// arguments are specified as an array of Objects.
    /// </summary>
    /// <remarks>
    /// This method will allocate and return by reference the output argument
    /// array.<newpara></newpara>
    /// M-Documentation:
    /// 锦标赛选择法（随便选两个标签，看谁的amt比较好就选谁）
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return</param>
    /// <param name= "argsOut">Array of Object output arguments</param>
    /// <param name= "argsIn">Array of Object input arguments</param>
    /// <param name= "varArgsIn">Array of Object representing variable input
    /// arguments</param>
    ///
    [MATLABSignature("selePopu", 1, 1, 0)]
    protected void selePopu(int numArgsOut, ref Object[] argsOut, Object[] argsIn, params Object[] varArgsIn)
    {
        mcr.EvaluateFunctionForTypeSafeCall("selePopu", numArgsOut, ref argsOut, argsIn, varArgsIn);
    }

    /// <summary>
    /// This method will cause a MATLAB figure window to behave as a modal dialog box.
    /// The method will not return until all the figure windows associated with this
    /// component have been closed.
    /// </summary>
    /// <remarks>
    /// An application should only call this method when required to keep the
    /// MATLAB figure window from disappearing.  Other techniques, such as calling
    /// Console.ReadLine() from the application should be considered where
    /// possible.</remarks>
    ///
    public void WaitForFiguresToDie()
    {
      mcr.WaitForFiguresToDie();
    }



    #endregion Methods

    #region Class Members

    private static MWMCR mcr= null;

    private static Exception ex_= null;

    private bool disposed= false;

    #endregion Class Members
  }
}
