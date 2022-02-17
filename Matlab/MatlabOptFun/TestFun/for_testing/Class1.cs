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

namespace TestFun
{

  /// <summary>
  /// The Class1 class provides a CLS compliant, MWArray interface to the MATLAB
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
    /// Provides a single output, 0-input MWArrayinterface to the crossFun MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// 定义两个数组
    /// </remarks>
    /// <returns>An MWArray containing the first output argument.</returns>
    ///
    public MWArray crossFun()
    {
      return mcr.EvaluateFunction("crossFun", new MWArray[]{});
    }


    /// <summary>
    /// Provides a single output, 1-input MWArrayinterface to the crossFun MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// 定义两个数组
    /// </remarks>
    /// <param name="len1">Input argument #1</param>
    /// <returns>An MWArray containing the first output argument.</returns>
    ///
    public MWArray crossFun(MWArray len1)
    {
      return mcr.EvaluateFunction("crossFun", len1);
    }


    /// <summary>
    /// Provides a single output, 2-input MWArrayinterface to the crossFun MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// 定义两个数组
    /// </remarks>
    /// <param name="len1">Input argument #1</param>
    /// <param name="len2">Input argument #2</param>
    /// <returns>An MWArray containing the first output argument.</returns>
    ///
    public MWArray crossFun(MWArray len1, MWArray len2)
    {
      return mcr.EvaluateFunction("crossFun", len1, len2);
    }


    /// <summary>
    /// Provides the standard 0-input MWArray interface to the crossFun MATLAB function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// 定义两个数组
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public MWArray[] crossFun(int numArgsOut)
    {
      return mcr.EvaluateFunction(numArgsOut, "crossFun", new MWArray[]{});
    }


    /// <summary>
    /// Provides the standard 1-input MWArray interface to the crossFun MATLAB function.
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
    public MWArray[] crossFun(int numArgsOut, MWArray len1)
    {
      return mcr.EvaluateFunction(numArgsOut, "crossFun", len1);
    }


    /// <summary>
    /// Provides the standard 2-input MWArray interface to the crossFun MATLAB function.
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
    public MWArray[] crossFun(int numArgsOut, MWArray len1, MWArray len2)
    {
      return mcr.EvaluateFunction(numArgsOut, "crossFun", len1, len2);
    }


    /// <summary>
    /// Provides an interface for the crossFun function in which the input and output
    /// arguments are specified as an array of MWArrays.
    /// </summary>
    /// <remarks>
    /// This method will allocate and return by reference the output argument
    /// array.<newpara></newpara>
    /// M-Documentation:
    /// 定义两个数组
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return</param>
    /// <param name= "argsOut">Array of MWArray output arguments</param>
    /// <param name= "argsIn">Array of MWArray input arguments</param>
    ///
    public void crossFun(int numArgsOut, ref MWArray[] argsOut, MWArray[] argsIn)
    {
      mcr.EvaluateFunction("crossFun", numArgsOut, ref argsOut, argsIn);
    }


    /// <summary>
    /// Provides a single output, 0-input MWArrayinterface to the inherFun MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// 初始化结构体
    /// </remarks>
    /// <returns>An MWArray containing the first output argument.</returns>
    ///
    public MWArray inherFun()
    {
      return mcr.EvaluateFunction("inherFun", new MWArray[]{});
    }


    /// <summary>
    /// Provides a single output, 1-input MWArrayinterface to the inherFun MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// 初始化结构体
    /// </remarks>
    /// <param name="inL1">Input argument #1</param>
    /// <returns>An MWArray containing the first output argument.</returns>
    ///
    public MWArray inherFun(MWArray inL1)
    {
      return mcr.EvaluateFunction("inherFun", inL1);
    }


    /// <summary>
    /// Provides a single output, 2-input MWArrayinterface to the inherFun MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// 初始化结构体
    /// </remarks>
    /// <param name="inL1">Input argument #1</param>
    /// <param name="inL2">Input argument #2</param>
    /// <returns>An MWArray containing the first output argument.</returns>
    ///
    public MWArray inherFun(MWArray inL1, MWArray inL2)
    {
      return mcr.EvaluateFunction("inherFun", inL1, inL2);
    }


    /// <summary>
    /// Provides a single output, 3-input MWArrayinterface to the inherFun MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// 初始化结构体
    /// </remarks>
    /// <param name="inL1">Input argument #1</param>
    /// <param name="inL2">Input argument #2</param>
    /// <param name="inL3">Input argument #3</param>
    /// <returns>An MWArray containing the first output argument.</returns>
    ///
    public MWArray inherFun(MWArray inL1, MWArray inL2, MWArray inL3)
    {
      return mcr.EvaluateFunction("inherFun", inL1, inL2, inL3);
    }


    /// <summary>
    /// Provides the standard 0-input MWArray interface to the inherFun MATLAB function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// 初始化结构体
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public MWArray[] inherFun(int numArgsOut)
    {
      return mcr.EvaluateFunction(numArgsOut, "inherFun", new MWArray[]{});
    }


    /// <summary>
    /// Provides the standard 1-input MWArray interface to the inherFun MATLAB function.
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
    public MWArray[] inherFun(int numArgsOut, MWArray inL1)
    {
      return mcr.EvaluateFunction(numArgsOut, "inherFun", inL1);
    }


    /// <summary>
    /// Provides the standard 2-input MWArray interface to the inherFun MATLAB function.
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
    public MWArray[] inherFun(int numArgsOut, MWArray inL1, MWArray inL2)
    {
      return mcr.EvaluateFunction(numArgsOut, "inherFun", inL1, inL2);
    }


    /// <summary>
    /// Provides the standard 3-input MWArray interface to the inherFun MATLAB function.
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
    public MWArray[] inherFun(int numArgsOut, MWArray inL1, MWArray inL2, MWArray inL3)
    {
      return mcr.EvaluateFunction(numArgsOut, "inherFun", inL1, inL2, inL3);
    }


    /// <summary>
    /// Provides an interface for the inherFun function in which the input and output
    /// arguments are specified as an array of MWArrays.
    /// </summary>
    /// <remarks>
    /// This method will allocate and return by reference the output argument
    /// array.<newpara></newpara>
    /// M-Documentation:
    /// 初始化结构体
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return</param>
    /// <param name= "argsOut">Array of MWArray output arguments</param>
    /// <param name= "argsIn">Array of MWArray input arguments</param>
    ///
    public void inherFun(int numArgsOut, ref MWArray[] argsOut, MWArray[] argsIn)
    {
      mcr.EvaluateFunction("inherFun", numArgsOut, ref argsOut, argsIn);
    }


    /// <summary>
    /// Provides a single output, 0-input MWArrayinterface to the mutatePopu MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// 没有什么好的算法，就干脆让机械臂重新生成一个新的长度数�
    /// ��
    /// </remarks>
    /// <returns>An MWArray containing the first output argument.</returns>
    ///
    public MWArray mutatePopu()
    {
      return mcr.EvaluateFunction("mutatePopu", new MWArray[]{});
    }


    /// <summary>
    /// Provides a single output, 1-input MWArrayinterface to the mutatePopu MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// 没有什么好的算法，就干脆让机械臂重新生成一个新的长度数�
    /// ��
    /// </remarks>
    /// <param name="len">Input argument #1</param>
    /// <returns>An MWArray containing the first output argument.</returns>
    ///
    public MWArray mutatePopu(MWArray len)
    {
      return mcr.EvaluateFunction("mutatePopu", len);
    }


    /// <summary>
    /// Provides a single output, 2-input MWArrayinterface to the mutatePopu MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// 没有什么好的算法，就干脆让机械臂重新生成一个新的长度数�
    /// ��
    /// </remarks>
    /// <param name="len">Input argument #1</param>
    /// <param name="nMuta">Input argument #2</param>
    /// <returns>An MWArray containing the first output argument.</returns>
    ///
    public MWArray mutatePopu(MWArray len, MWArray nMuta)
    {
      return mcr.EvaluateFunction("mutatePopu", len, nMuta);
    }


    /// <summary>
    /// Provides a single output, 3-input MWArrayinterface to the mutatePopu MATLAB
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
    /// <returns>An MWArray containing the first output argument.</returns>
    ///
    public MWArray mutatePopu(MWArray len, MWArray nMuta, MWArray sumLen)
    {
      return mcr.EvaluateFunction("mutatePopu", len, nMuta, sumLen);
    }


    /// <summary>
    /// Provides the standard 0-input MWArray interface to the mutatePopu MATLAB
    /// function.
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
    public MWArray[] mutatePopu(int numArgsOut)
    {
      return mcr.EvaluateFunction(numArgsOut, "mutatePopu", new MWArray[]{});
    }


    /// <summary>
    /// Provides the standard 1-input MWArray interface to the mutatePopu MATLAB
    /// function.
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
    public MWArray[] mutatePopu(int numArgsOut, MWArray len)
    {
      return mcr.EvaluateFunction(numArgsOut, "mutatePopu", len);
    }


    /// <summary>
    /// Provides the standard 2-input MWArray interface to the mutatePopu MATLAB
    /// function.
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
    public MWArray[] mutatePopu(int numArgsOut, MWArray len, MWArray nMuta)
    {
      return mcr.EvaluateFunction(numArgsOut, "mutatePopu", len, nMuta);
    }


    /// <summary>
    /// Provides the standard 3-input MWArray interface to the mutatePopu MATLAB
    /// function.
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
    public MWArray[] mutatePopu(int numArgsOut, MWArray len, MWArray nMuta, MWArray 
                          sumLen)
    {
      return mcr.EvaluateFunction(numArgsOut, "mutatePopu", len, nMuta, sumLen);
    }


    /// <summary>
    /// Provides an interface for the mutatePopu function in which the input and output
    /// arguments are specified as an array of MWArrays.
    /// </summary>
    /// <remarks>
    /// This method will allocate and return by reference the output argument
    /// array.<newpara></newpara>
    /// M-Documentation:
    /// 没有什么好的算法，就干脆让机械臂重新生成一个新的长度数�
    /// ��
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return</param>
    /// <param name= "argsOut">Array of MWArray output arguments</param>
    /// <param name= "argsIn">Array of MWArray input arguments</param>
    ///
    public void mutatePopu(int numArgsOut, ref MWArray[] argsOut, MWArray[] argsIn)
    {
      mcr.EvaluateFunction("mutatePopu", numArgsOut, ref argsOut, argsIn);
    }


    /// <summary>
    /// Provides a single output, 0-input MWArrayinterface to the optFun MATLAB function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// 建立机器人模型
    /// theta    d        a        alpha     offset
    /// </remarks>
    /// <returns>An MWArray containing the first output argument.</returns>
    ///
    public MWArray optFun()
    {
      return mcr.EvaluateFunction("optFun", new MWArray[]{});
    }


    /// <summary>
    /// Provides a single output, 1-input MWArrayinterface to the optFun MATLAB function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// 建立机器人模型
    /// theta    d        a        alpha     offset
    /// </remarks>
    /// <param name="inL">Input argument #1</param>
    /// <returns>An MWArray containing the first output argument.</returns>
    ///
    public MWArray optFun(MWArray inL)
    {
      return mcr.EvaluateFunction("optFun", inL);
    }


    /// <summary>
    /// Provides a single output, 2-input MWArrayinterface to the optFun MATLAB function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// 建立机器人模型
    /// theta    d        a        alpha     offset
    /// </remarks>
    /// <param name="inL">Input argument #1</param>
    /// <param name="Posture">Input argument #2</param>
    /// <returns>An MWArray containing the first output argument.</returns>
    ///
    public MWArray optFun(MWArray inL, MWArray Posture)
    {
      return mcr.EvaluateFunction("optFun", inL, Posture);
    }


    /// <summary>
    /// Provides a single output, 3-input MWArrayinterface to the optFun MATLAB function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// 建立机器人模型
    /// theta    d        a        alpha     offset
    /// </remarks>
    /// <param name="inL">Input argument #1</param>
    /// <param name="Posture">Input argument #2</param>
    /// <param name="Arr">Input argument #3</param>
    /// <returns>An MWArray containing the first output argument.</returns>
    ///
    public MWArray optFun(MWArray inL, MWArray Posture, MWArray Arr)
    {
      return mcr.EvaluateFunction("optFun", inL, Posture, Arr);
    }


    /// <summary>
    /// Provides a single output, 4-input MWArrayinterface to the optFun MATLAB function.
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
    /// <returns>An MWArray containing the first output argument.</returns>
    ///
    public MWArray optFun(MWArray inL, MWArray Posture, MWArray Arr, MWArray posLen)
    {
      return mcr.EvaluateFunction("optFun", inL, Posture, Arr, posLen);
    }


    /// <summary>
    /// Provides the standard 0-input MWArray interface to the optFun MATLAB function.
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
    public MWArray[] optFun(int numArgsOut)
    {
      return mcr.EvaluateFunction(numArgsOut, "optFun", new MWArray[]{});
    }


    /// <summary>
    /// Provides the standard 1-input MWArray interface to the optFun MATLAB function.
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
    public MWArray[] optFun(int numArgsOut, MWArray inL)
    {
      return mcr.EvaluateFunction(numArgsOut, "optFun", inL);
    }


    /// <summary>
    /// Provides the standard 2-input MWArray interface to the optFun MATLAB function.
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
    public MWArray[] optFun(int numArgsOut, MWArray inL, MWArray Posture)
    {
      return mcr.EvaluateFunction(numArgsOut, "optFun", inL, Posture);
    }


    /// <summary>
    /// Provides the standard 3-input MWArray interface to the optFun MATLAB function.
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
    public MWArray[] optFun(int numArgsOut, MWArray inL, MWArray Posture, MWArray Arr)
    {
      return mcr.EvaluateFunction(numArgsOut, "optFun", inL, Posture, Arr);
    }


    /// <summary>
    /// Provides the standard 4-input MWArray interface to the optFun MATLAB function.
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
    public MWArray[] optFun(int numArgsOut, MWArray inL, MWArray Posture, MWArray Arr, 
                      MWArray posLen)
    {
      return mcr.EvaluateFunction(numArgsOut, "optFun", inL, Posture, Arr, posLen);
    }


    /// <summary>
    /// Provides an interface for the optFun function in which the input and output
    /// arguments are specified as an array of MWArrays.
    /// </summary>
    /// <remarks>
    /// This method will allocate and return by reference the output argument
    /// array.<newpara></newpara>
    /// M-Documentation:
    /// 建立机器人模型
    /// theta    d        a        alpha     offset
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return</param>
    /// <param name= "argsOut">Array of MWArray output arguments</param>
    /// <param name= "argsIn">Array of MWArray input arguments</param>
    ///
    public void optFun(int numArgsOut, ref MWArray[] argsOut, MWArray[] argsIn)
    {
      mcr.EvaluateFunction("optFun", numArgsOut, ref argsOut, argsIn);
    }


    /// <summary>
    /// Provides a single output, 0-input MWArrayinterface to the selePopu MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// 锦标赛选择法（随便选两个标签，看谁的amt比较好就选谁）
    /// </remarks>
    /// <returns>An MWArray containing the first output argument.</returns>
    ///
    public MWArray selePopu()
    {
      return mcr.EvaluateFunction("selePopu", new MWArray[]{});
    }


    /// <summary>
    /// Provides a single output, 1-input MWArrayinterface to the selePopu MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// 锦标赛选择法（随便选两个标签，看谁的amt比较好就选谁）
    /// </remarks>
    /// <param name="Parent">Input argument #1</param>
    /// <returns>An MWArray containing the first output argument.</returns>
    ///
    public MWArray selePopu(MWArray Parent)
    {
      return mcr.EvaluateFunction("selePopu", Parent);
    }


    /// <summary>
    /// Provides the standard 0-input MWArray interface to the selePopu MATLAB function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// 锦标赛选择法（随便选两个标签，看谁的amt比较好就选谁）
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public MWArray[] selePopu(int numArgsOut)
    {
      return mcr.EvaluateFunction(numArgsOut, "selePopu", new MWArray[]{});
    }


    /// <summary>
    /// Provides the standard 1-input MWArray interface to the selePopu MATLAB function.
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
    public MWArray[] selePopu(int numArgsOut, MWArray Parent)
    {
      return mcr.EvaluateFunction(numArgsOut, "selePopu", Parent);
    }


    /// <summary>
    /// Provides an interface for the selePopu function in which the input and output
    /// arguments are specified as an array of MWArrays.
    /// </summary>
    /// <remarks>
    /// This method will allocate and return by reference the output argument
    /// array.<newpara></newpara>
    /// M-Documentation:
    /// 锦标赛选择法（随便选两个标签，看谁的amt比较好就选谁）
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return</param>
    /// <param name= "argsOut">Array of MWArray output arguments</param>
    /// <param name= "argsIn">Array of MWArray input arguments</param>
    ///
    public void selePopu(int numArgsOut, ref MWArray[] argsOut, MWArray[] argsIn)
    {
      mcr.EvaluateFunction("selePopu", numArgsOut, ref argsOut, argsIn);
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
