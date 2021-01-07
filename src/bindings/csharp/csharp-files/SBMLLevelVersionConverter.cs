using System;
using System.Runtime.InteropServices;
 
//------------------------------------------------------------------------------
// <auto-generated />
//
// This file was automatically generated by SWIG (http://www.swig.org).
// Version 4.0.2
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
@htmlinclude pkg-marker-core.html Whole-document SBML Level/Version converter.
 *
 * @htmlinclude libsbml-facility-only-warning.html
 *
 * This SBML converter takes an SBML document having one SBML Level+Version
 * combination, and attempts to convert it to an SBML document having a
 * different Level+Version combination.
 *
 * This class is also the basis for
 * SBMLDocument::setLevelAndVersion(@if java long, long, boolean@endif).
 *
 * @section SBMLLevelVersionConverter-usage Configuration and use of SBMLLevelVersionConverter
 *
 * SBMLLevelVersionConverter is enabled by creating a ConversionProperties
 * object with the option @c 'setLevelAndVersion', and passing this
 * properties object to SBMLDocument::convert(@if java
 * ConversionProperties@endif).  The target SBML Level and Version
 * combination are determined by the value of the SBML namespace set on the
 * ConversionProperties object (using
 * ConversionProperties::setTargetNamespaces(SBMLNamespaces targetNS)).
 *
 * In addition, this converter offers the following options:
 *
 * @li @c 'strict': If this option has the value @c true, then the validity
 * of the SBML document will be strictly preserved.  This means that SBML
 * validation will be performed, and if the original model is not valid or
 * semantics cannot be preserved in the converted model, then conversion will
 * not be performed.  Conversely, if this option is set to @c false, model
 * conversion will always be performed; if any errors are detected related to
 * altered semantics, the errors will be logged in the usual way (i.e., the
 * error log on the SBMLDocument object).
 *
 * @li @c 'addDefaultUnits': By default, a conversion from SBML Level&nbsp;2
 * to Level&nbsp;3 will explicitly add UnitDefinition objects and unit
 * attributes on the Model object to define units that are implicitly defined
 * in SBML Level&nbsp;2.  This is usually desirable because in SBML
 * Level&nbsp;3, there are no default units and a conversion from
 * Level&nbsp;2 that did @em not add unit definitions would actually result
 * in a loss of information.  However, some users or software tools may not
 * need or want this, or worse, may be fooled into thinking that libSBML has
 * somehow inferred the proper units for model quantities.  (It has not; it
 * merely adds generic predefined units.)  This option lets callers control
 * this behavior.
 *
 *
 * @section using-converters General information about the use of SBML converters
 *
 * The use of all the converters follows a similar approach.  First, one
 * creates a ConversionProperties object and calls
 * ConversionProperties::addOption(@if java ConversionOption@endif)
 * on this object with one argument: a text string that identifies the desired
 * converter.  (The text string is specific to each converter; consult the
 * documentation for a given converter to find out how it should be enabled.)
 *
 * Next, for some converters, the caller can optionally set some
 * converter-specific properties using additional calls to
 * ConversionProperties::addOption(@if java ConversionOption@endif).
 * Many converters provide the ability to
 * configure their behavior to some extent; this is realized through the use
 * of properties that offer different options.  The default property values
 * for each converter can be interrogated using the method
 * SBMLConverter::getDefaultProperties() on the converter class in question .
 *
 * Finally, the caller should invoke the method
 * SBMLDocument::convert(@if java ConversionProperties@endif)
 * with the ConversionProperties object as an argument.
 *
 * @subsection converter-example Example of invoking an SBML converter
 *
 * The following code fragment illustrates an example using
 * SBMLReactionConverter, which is invoked using the option string
 * @c 'replaceReactions':
 *
 * @if cpp
 * @code{.cpp}
ConversionProperties props;
props.addOption('replaceReactions');
@endcode
@endif
@if python
@code{.py}
config = ConversionProperties()
if config != None:
  config.addOption('replaceReactions')
@endcode
@endif
@if java
@code{.java}
ConversionProperties props = new ConversionProperties();
if (props != null) {
  props.addOption('replaceReactions');
} else {
  // Deal with error.
}
@endcode
@endif
 *
 * In the case of SBMLReactionConverter, there are no options to affect
 * its behavior, so the next step is simply to invoke the converter on
 * an SBMLDocument object.  Continuing the example code:
 *
 * @if cpp
 * @code{.cpp}
// Assume that the variable 'document' has been set to an SBMLDocument object.
int status = document->convert(props);
if (status != LIBSBML_OPERATION_SUCCESS)
{
  cerr << 'Unable to perform conversion due to the following:' << endl;
  document->printErrors(cerr);
}
@endcode
@endif
@if python
@code{.py}
  # Assume that the variable 'document' has been set to an SBMLDocument object.
  status = document.convert(config)
  if status != LIBSBML_OPERATION_SUCCESS:
    # Handle error somehow.
    print('Error: conversion failed due to the following:')
    document.printErrors()
@endcode
@endif
@if java
@code{.java}
  // Assume that the variable 'document' has been set to an SBMLDocument object.
  status = document.convert(config);
  if (status != libsbml.LIBSBML_OPERATION_SUCCESS)
  {
    // Handle error somehow.
    System.out.println('Error: conversion failed due to the following:');
    document.printErrors();
  }
@endcode
@endif
 *
 * Here is an example of using a converter that offers an option. The
 * following code invokes SBMLStripPackageConverter to remove the
 * SBML Level&nbsp;3 @em %Layout package from a model.  It sets the name
 * of the package to be removed by adding a value for the option named
 * @c 'package' defined by that converter:
 *
 * @if cpp
 * @code{.cpp}
ConversionProperties props;
props.addOption('stripPackage');
props.addOption('package', 'layout');

int status = document->convert(props);
if (status != LIBSBML_OPERATION_SUCCESS)
{
    cerr << 'Unable to strip the Layout package from the model';
    cerr << 'Error returned: ' << status;
}
@endcode
@endif
@if python
@code{.py}
def strip_layout_example(document):
  config = ConversionProperties()
  if config != None:
    config.addOption('stripPackage')
    config.addOption('package', 'layout')
    status = document.convert(config)
    if status != LIBSBML_OPERATION_SUCCESS:
      # Handle error somehow.
      print('Error: unable to strip the Layout package.')
      print('LibSBML returned error: ' + OperationReturnValue_toString(status).strip())
  else:
    # Handle error somehow.
    print('Error: unable to create ConversionProperties object')
@endcode
@endif
@if java
@code{.java}
ConversionProperties config = new ConversionProperties();
if (config != None) {
  config.addOption('stripPackage');
  config.addOption('package', 'layout');
  status = document.convert(config);
  if (status != LIBSBML_OPERATION_SUCCESS) {
    // Handle error somehow.
    System.out.println('Error: unable to strip the Layout package');
    document.printErrors();
  }
} else {
  // Handle error somehow.
  System.out.println('Error: unable to create ConversionProperties object');
}
@endcode
@endif
 *
 * @subsection available-converters Available SBML converters in libSBML
 *
 * LibSBML provides a number of built-in converters; by convention, their
 * names end in @em Converter. The following are the built-in converters
 * provided by libSBML @htmlinclude libsbml-version.html:
 *
 * @copydetails doc_list_of_libsbml_converters
 *
 *
 */

public class SBMLLevelVersionConverter : SBMLConverter {
	private HandleRef swigCPtr;
	
	internal SBMLLevelVersionConverter(IntPtr cPtr, bool cMemoryOwn) : base(libsbmlPINVOKE.SBMLLevelVersionConverter_SWIGUpcast(cPtr), cMemoryOwn)
	{
		//super(libsbmlPINVOKE.SBMLLevelVersionConverterUpcast(cPtr), cMemoryOwn);
		swigCPtr = new HandleRef(this, cPtr);
	}
	
	internal static HandleRef getCPtr(SBMLLevelVersionConverter obj)
	{
		return (obj == null) ? new HandleRef(null, IntPtr.Zero) : obj.swigCPtr;
	}
	
	internal static HandleRef getCPtrAndDisown (SBMLLevelVersionConverter obj)
	{
		HandleRef ptr = new HandleRef(null, IntPtr.Zero);
		
		if (obj != null)
		{
			ptr             = obj.swigCPtr;
			obj.swigCMemOwn = false;
		}
		
		return ptr;
	}

  protected override void Dispose(bool disposing) {
    lock(this) {
      if (swigCPtr.Handle != global::System.IntPtr.Zero) {
        if (swigCMemOwn) {
          swigCMemOwn = false;
          libsbmlPINVOKE.delete_SBMLLevelVersionConverter(swigCPtr);
        }
        swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
      }
      base.Dispose(disposing);
    }
  }

  
/** */ /* libsbml-internal */ public
 static void init() {
    libsbmlPINVOKE.SBMLLevelVersionConverter_init();
  }

  
/**
   * Creates a new SBMLLevelVersionConverter object.
   */ public
 SBMLLevelVersionConverter() : this(libsbmlPINVOKE.new_SBMLLevelVersionConverter__SWIG_0(), true) {
  }

  
/**
   * Copy constructor; creates a copy of an SBMLLevelVersionConverter
   * object.
   *
   * @param obj the SBMLLevelVersionConverter object to copy.
   */ public
 SBMLLevelVersionConverter(SBMLLevelVersionConverter obj) : this(libsbmlPINVOKE.new_SBMLLevelVersionConverter__SWIG_1(SBMLLevelVersionConverter.getCPtr(obj)), true) {
    if (libsbmlPINVOKE.SWIGPendingException.Pending) throw libsbmlPINVOKE.SWIGPendingException.Retrieve();
  }

  
/**
   * Creates and returns a deep copy of this SBMLLevelVersionConverter
   * object.
   *
   * @return a (deep) copy of this converter.
   */ public new
 SBMLConverter clone() {
    global::System.IntPtr cPtr = libsbmlPINVOKE.SBMLLevelVersionConverter_clone(swigCPtr);
    SBMLLevelVersionConverter ret = (cPtr == global::System.IntPtr.Zero) ? null : new SBMLLevelVersionConverter(cPtr, true);
    return ret;
  }

  
/**
   * Returns @c true if this converter object's properties match the given
   * properties.
   *
   * A typical use of this method involves creating a ConversionProperties
   * object, setting the options desired, and then calling this method on
   * an SBMLLevelVersionConverter object to find out if the object's
   * property values match the given ones.  This method is also used by
   * SBMLConverterRegistry::getConverterFor(@if java ConversionProperties@endif)
   * to search across all registered converters for one matching particular
   * properties.
   *
   * @param props the properties to match.
   *
   * @return @c true if this converter's properties match, @c false
   * otherwise.
   */ public new
 bool matchesProperties(ConversionProperties props) {
    bool ret = libsbmlPINVOKE.SBMLLevelVersionConverter_matchesProperties(swigCPtr, ConversionProperties.getCPtr(props));
    if (libsbmlPINVOKE.SWIGPendingException.Pending) throw libsbmlPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  
/**
   * Perform the conversion.
   *
   * This method causes the converter to do the actual conversion work,
   * that is, to convert the SBMLDocument object set by
   * SBMLConverter::setDocument(@if java SBMLDocument@endif) and
   * with the configuration options set by
   * SBMLConverter::setProperties(@if java ConversionProperties@endif).
   *
   *
 * @return integer value indicating success/failure of the
 * function.  @if clike The value is drawn from the
 * enumeration #OperationReturnValues_t. @endif The possible values
 * returned by this function are:
 * @li @link libsbml#LIBSBML_OPERATION_SUCCESS LIBSBML_OPERATION_SUCCESS@endlink
   * @li @link libsbml#LIBSBML_OPERATION_FAILED LIBSBML_OPERATION_FAILED@endlink
   * @li @link libsbml#LIBSBML_CONV_INVALID_TARGET_NAMESPACE LIBSBML_CONV_INVALID_TARGET_NAMESPACE@endlink
   * @li @link libsbml#LIBSBML_CONV_PKG_CONVERSION_NOT_AVAILABLE LIBSBML_CONV_PKG_CONVERSION_NOT_AVAILABLE@endlink
   * @li @link libsbml#LIBSBML_CONV_INVALID_SRC_DOCUMENT LIBSBML_CONV_INVALID_SRC_DOCUMENT@endlink
   */ public new
 int convert() {
    int ret = libsbmlPINVOKE.SBMLLevelVersionConverter_convert(swigCPtr);
    return ret;
  }

  
/**
   * Returns the default properties of this converter.
   *
   * A given converter exposes one or more properties that can be adjusted
   * in order to influence the behavior of the converter.  This method
   * returns the @em default property settings for this converter.  It is
   * meant to be called in order to discover all the settings for the
   * converter object.
   *
   * @return the ConversionProperties object describing the default properties
   * for this converter.
   */ public new
 ConversionProperties getDefaultProperties() {
    ConversionProperties ret = new ConversionProperties(libsbmlPINVOKE.SBMLLevelVersionConverter_getDefaultProperties(swigCPtr), true);
    return ret;
  }

  
/**
   * Returns the target SBML Level for the conversion.
   *
   * @return an integer indicating the SBML Level.
   */ public
 long getTargetLevel() { return (long)libsbmlPINVOKE.SBMLLevelVersionConverter_getTargetLevel(swigCPtr); }

  
/**
   * Returns the target SBML Version for the conversion.
   *
   * @return an integer indicating the Version within the SBML Level.
   */ public
 long getTargetVersion() { return (long)libsbmlPINVOKE.SBMLLevelVersionConverter_getTargetVersion(swigCPtr); }

  
/**
   * Returns the flag indicating whether the conversion has been set to 'strict'.
   *
   * @return @c true if strict validity has been requested, @c false
   * otherwise.
   */ public
 bool getValidityFlag() {
    bool ret = libsbmlPINVOKE.SBMLLevelVersionConverter_getValidityFlag(swigCPtr);
    return ret;
  }

  
/**
   * Returns the flag indicating whether default units should be added when
   * converting to L3 or not.
   *
   * @return @c true if default units should be added, @c false
   * otherwise.
   */ public
 bool getAddDefaultUnits() {
    bool ret = libsbmlPINVOKE.SBMLLevelVersionConverter_getAddDefaultUnits(swigCPtr);
    return ret;
  }

}

}
