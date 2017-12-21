using System;
using System.Runtime.InteropServices;

//------------------------------------------------------------------------------
// <auto-generated />
//
// This file was automatically generated by SWIG (http://www.swig.org).
// Version 3.0.12
//
// Do not make changes to this file unless you know what you are doing--modify
// the SWIG interface file instead.
//------------------------------------------------------------------------------

namespace libsbmlcs {

 using System;
 using System.Runtime.InteropServices;

/**
 * @sbmlpackage{core}
 *
@htmlinclude pkg-marker-core.html Registry of all libSBML SBML converters.
 *
 * @htmlinclude libsbml-facility-only-warning.html
 *
 * LibSBML provides facilities for transforming and converting SBML
 * documents in various ways.  These transformations can involve
 * essentially anything that can be written algorithmically; examples
 * include converting the units of measurement in a model, or converting
 * from one Level+Version combination of SBML to another.  Converters are
 * implemented as objects derived from the class SBMLConverter.
 *
 * The converter registry, implemented as a singleton object of class
 * SBMLConverterRegistry, maintains a list of known converters and provides
 * methods for discovering them.  Callers can use the method
 * SBMLConverterRegistry::getNumConverters() to find out how many
 * converters are registered, then use
 * SBMLConverterRegistry::getConverterByIndex(@if java int@endif) to
 * iterate over each one; alternatively, callers can use
 * SBMLConverterRegistry::getConverterFor(@if java ConversionProperties@endif)
 * to search for a converter having specific properties.
 */

public class SBMLConverterRegistry : global::System.IDisposable {
	private HandleRef swigCPtr;
	protected bool swigCMemOwn;

	internal SBMLConverterRegistry(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr    = new HandleRef(this, cPtr);
	}

	internal static HandleRef getCPtr(SBMLConverterRegistry obj)
	{
		return (obj == null) ? new HandleRef(null, IntPtr.Zero) : obj.swigCPtr;
	}

	internal static HandleRef getCPtrAndDisown (SBMLConverterRegistry obj)
	{
		HandleRef ptr = new HandleRef(null, IntPtr.Zero);

		if (obj != null)
		{
			ptr             = obj.swigCPtr;
			obj.swigCMemOwn = false;
		}

		return ptr;
	}

  ~SBMLConverterRegistry() {
    Dispose();
  }

  public virtual void Dispose() {
    lock(this) {
      if (swigCPtr.Handle != global::System.IntPtr.Zero) {
        if (swigCMemOwn) {
          swigCMemOwn = false;
          libsbmlPINVOKE.delete_SBMLConverterRegistry(swigCPtr);
        }
        swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
      }
      global::System.GC.SuppressFinalize(this);
    }
  }


/**
   * Returns the singleton instance for the converter registry.
   *
   * Prior to using the registry, callers have to obtain a copy of the
   * registry.  This static method provides the means for doing that.
   *
   * @return the singleton for the converter registry.
   */ public
 static SBMLConverterRegistry getInstance() {
    SBMLConverterRegistry ret = new SBMLConverterRegistry(libsbmlPINVOKE.SBMLConverterRegistry_getInstance(), false);
    return ret;
  }


/**
   * Adds the given converter to the registry of SBML converters.
   *
   * @param converter the converter to add to the registry.
   *
   *
 * @return integer value indicating success/failure of the
 * function.  @if clike The value is drawn from the
 * enumeration #OperationReturnValues_t. @endif The possible values
 * returned by this function are:
 * @li @link libsbml#LIBSBML_OPERATION_SUCCESS LIBSBML_OPERATION_SUCCESS@endlink
   * @li @link libsbml#LIBSBML_INVALID_OBJECT LIBSBML_INVALID_OBJECT@endlink
   */ public
 int addConverter(SBMLConverter converter) {
    int ret = libsbmlPINVOKE.SBMLConverterRegistry_addConverter(swigCPtr, SBMLConverter.getCPtr(converter));
    return ret;
  }


/**
   * Returns the converter with the given index number.
   *
   * Converters are given arbitrary index numbers by the registry.  Callers
   * can use the method SBMLConverterRegistry::getNumConverters() to find
   * out how many converters are registered, then use this method to
   * iterate over the list and obtain each one in turn.
   *
   * @param index the zero-based index of the converter to fetch.
   *
   * @return the converter with the given index number, or @c null if the
   * number is less than @c 0 or there is no converter at the given index
   * position.
   */ public
 SBMLConverter getConverterByIndex(int index) {
	SBMLConverter ret
	    = (SBMLConverter) libsbml.DowncastSBMLConverter(libsbmlPINVOKE.SBMLConverterRegistry_getConverterByIndex(swigCPtr, index), false);
	return ret;
}


/**
   * Returns the converter that best matches the given configuration
   * properties.
   *
   * Many converters provide the ability to configure their behavior.  This
   * is realized through the use of @em properties that offer different @em
   * options.  The present method allows callers to search for converters
   * that have specific property values.  Callers can do this by creating a
   * ConversionProperties object, adding the desired option(s) to the
   * object, then passing the object to this method.
   *
   * @param props a ConversionProperties object defining the properties
   * to match against.
   *
   * @return the converter matching the properties, or @c null if no
   * suitable converter is found.
   *
   * @see getConverterByIndex(@if java int@endif)
   */ public
 SBMLConverter getConverterFor(ConversionProperties props) {
	SBMLConverter ret
	    = (SBMLConverter) libsbml.DowncastSBMLConverter(libsbmlPINVOKE.SBMLConverterRegistry_getConverterFor(swigCPtr, ConversionProperties.getCPtr(props)), false);
    if (libsbmlPINVOKE.SWIGPendingException.Pending) throw libsbmlPINVOKE.SWIGPendingException.Retrieve();
	return ret;
}


/**
   * Returns the number of converters known by the registry.
   *
   * @return the number of registered converters.
   *
   * @see getConverterByIndex(@if java int@endif)
   */ public
 int getNumConverters() {
    int ret = libsbmlPINVOKE.SBMLConverterRegistry_getNumConverters(swigCPtr);
    return ret;
  }

}

}
