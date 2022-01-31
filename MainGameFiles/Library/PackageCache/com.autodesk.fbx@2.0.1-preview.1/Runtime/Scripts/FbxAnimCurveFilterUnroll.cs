//------------------------------------------------------------------------------
// <auto-generated />
//
// This file was automatically generated by SWIG (http://www.swig.org).
// Version 3.0.12
//
// Do not make changes to this file unless you know what you are doing--modify
// the SWIG interface file instead.
//------------------------------------------------------------------------------

namespace Autodesk.Fbx {

public class FbxAnimCurveFilterUnroll : global::System.IDisposable {
  private global::System.Runtime.InteropServices.HandleRef swigCPtr;
  protected bool swigCMemOwn;

  internal FbxAnimCurveFilterUnroll(global::System.IntPtr cPtr, bool cMemoryOwn) {
    swigCMemOwn = cMemoryOwn;
    swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
  }

  internal static global::System.Runtime.InteropServices.HandleRef getCPtr(FbxAnimCurveFilterUnroll obj) {
    return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
  }

  ~FbxAnimCurveFilterUnroll() {
    Dispose();
  }

  public virtual void Dispose() {
    lock(this) {
      if (swigCPtr.Handle != global::System.IntPtr.Zero) {
        if (swigCMemOwn) {
          swigCMemOwn = false;
          NativeMethods.delete_FbxAnimCurveFilterUnroll(swigCPtr);
        }
        swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
      }
      global::System.GC.SuppressFinalize(this);
    }
  }

  public FbxAnimCurveFilterUnroll() : this(NativeMethods.new_FbxAnimCurveFilterUnroll(), true) {
  }

  public virtual bool NeedApply(FbxAnimCurveNode pCurveNode, FbxStatus pStatus) {
    bool ret = NativeMethods.FbxAnimCurveFilterUnroll_NeedApply__SWIG_0(swigCPtr, FbxAnimCurveNode.getCPtr(pCurveNode), FbxStatus.getCPtr(pStatus));
    if (NativeMethods.SWIGPendingException.Pending) throw NativeMethods.SWIGPendingException.Retrieve();
    return ret;
  }

  public virtual bool NeedApply(FbxAnimCurveNode pCurveNode) {
    bool ret = NativeMethods.FbxAnimCurveFilterUnroll_NeedApply__SWIG_1(swigCPtr, FbxAnimCurveNode.getCPtr(pCurveNode));
    if (NativeMethods.SWIGPendingException.Pending) throw NativeMethods.SWIGPendingException.Retrieve();
    return ret;
  }

  public virtual bool Apply(FbxAnimCurveNode pCurveNode, FbxStatus pStatus) {
    bool ret = NativeMethods.FbxAnimCurveFilterUnroll_Apply__SWIG_0(swigCPtr, FbxAnimCurveNode.getCPtr(pCurveNode), FbxStatus.getCPtr(pStatus));
    if (NativeMethods.SWIGPendingException.Pending) throw NativeMethods.SWIGPendingException.Retrieve();
    return ret;
  }

  public virtual bool Apply(FbxAnimCurveNode pCurveNode) {
    bool ret = NativeMethods.FbxAnimCurveFilterUnroll_Apply__SWIG_1(swigCPtr, FbxAnimCurveNode.getCPtr(pCurveNode));
    if (NativeMethods.SWIGPendingException.Pending) throw NativeMethods.SWIGPendingException.Retrieve();
    return ret;
  }

  public virtual void Reset() {
    NativeMethods.FbxAnimCurveFilterUnroll_Reset(swigCPtr);
    if (NativeMethods.SWIGPendingException.Pending) throw NativeMethods.SWIGPendingException.Retrieve();
  }

}

}
