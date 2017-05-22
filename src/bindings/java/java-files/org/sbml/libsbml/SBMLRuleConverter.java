/* ----------------------------------------------------------------------------
 * This file was automatically generated by SWIG (http://www.swig.org).
 * Version 2.0.6
 *
 * Do not make changes to this file unless you know what you are doing--modify
 * the SWIG interface file instead.
 * ----------------------------------------------------------------------------- */

package org.sbml.libsbml;

/**
 *  Converter that sorts SBML rules and assignments.
 <p>
 * <p style='color: #777; font-style: italic'>
This class of objects is defined by libSBML only and has no direct
equivalent in terms of SBML components.  It is a class used in
the implementation of extra functionality provided by libSBML.
</p>

 <p>
 * This converter reorders assignments in a model.  Specifically, it sorts
 * the list of assignment rules (i.e., the {@link AssignmentRule} objects contained
 * in the ListOfAssignmentRules within the {@link Model} object) and the initial
 * assignments (i.e., the {@link InitialAssignment} objects contained in the
 * {@link ListOfInitialAssignments}) such that, within each set, assignments that
 * depend on <em>prior</em> values are placed <em>after</em> the values are set.  For
 * example, if there is an assignment rule stating <i>a = b + 1</i>, and
 * another rule stating <i>b = 3</i>, the list of rules is sorted and the
 * rules are arranged so that the rule for <i>b = 3</i> appears <em>before</em>
 * the rule for <i>a = b + 1</i>.  Similarly, if dependencies of this
 * sort exist in the list of initial assignments in the model, the initial
 * assignments are sorted as well.
 <p>
 * Beginning with SBML Level 2, assignment rules have no ordering
 * required&mdash;the order in which the rules appear in an SBML file has
 * no significance.  Software tools, however, may need to reorder
 * assignments for purposes of evaluating them.  For example, for
 * simulators that use time integration methods, it would be a good idea to
 * reorder assignment rules such as the following,
 <p>
 * <i>b = a + 10 seconds</i><br>
 * <i>a = time</i>
 <p>
 * so that the evaluation of the rules is independent of integrator
 * step sizes. (This is due to the fact that, in this case, the order in
 * which the rules are evaluated changes the result.)  {@link SBMLRuleConverter}
 * can be used to reorder the SBML objects regardless of whether the
 * input file contained them in the desired order.
 <p>
 * Note that the two sets of SBML assignments (list of assignment rules on
 * the one hand, and list of initial assignments on the other hand) are
 * handled <em>independently</em>.  In an SBML model, these entities are treated
 * differently and no amount of sorting can deal with inter-dependencies
 * between assignments of the two kinds.
<p>
 * <h2>Configuration and use of {@link SBMLRuleConverter}</h2>
 <p>
 * {@link SBMLRuleConverter} is enabled by creating a {@link ConversionProperties} object
 * with the option <code>'sortRules'</code>, and passing this properties object to
 * {@link SBMLDocument#convert(ConversionProperties)}.  This
 * converter offers no other options.
 <p>
 * <p>
 * <h2>General information about the use of SBML converters</h2>
 <p>
 * The use of all the converters follows a similar approach.  First, one
 * creates a {@link ConversionProperties} object and calls
 * {@link ConversionProperties#addOption(ConversionOption)}
 * on this object with one argument: a text string that identifies the desired
 * converter.  (The text string is specific to each converter; consult the
 * documentation for a given converter to find out how it should be enabled.)
 <p>
 * Next, for some converters, the caller can optionally set some
 * converter-specific properties using additional calls to
 * {@link ConversionProperties#addOption(ConversionOption)}.
 * Many converters provide the ability to
 * configure their behavior to some extent; this is realized through the use
 * of properties that offer different options.  The default property values
 * for each converter can be interrogated using the method
 * {@link SBMLConverter#getDefaultProperties()} on the converter class in question .
 <p>
 * Finally, the caller should invoke the method
 * {@link SBMLDocument#convert(ConversionProperties)}
 * with the {@link ConversionProperties} object as an argument.
 <p>
 * <h3>Example of invoking an SBML converter</h3>
 <p>
 * The following code fragment illustrates an example using
 * {@link SBMLReactionConverter}, which is invoked using the option string
 * <code>'replaceReactions':</code>
 <p>
<pre class='fragment'>
{@link ConversionProperties} props = new {@link ConversionProperties}();
if (props != null) {
  props.addOption('replaceReactions');
} else {
  // Deal with error.
}
</pre>
<p>
 * In the case of {@link SBMLReactionConverter}, there are no options to affect
 * its behavior, so the next step is simply to invoke the converter on
 * an {@link SBMLDocument} object.  Continuing the example code:
 <p>
<pre class='fragment'>
  // Assume that the variable 'document' has been set to an {@link SBMLDocument} object.
  status = document.convert(config);
  if (status != libsbml.LIBSBML_OPERATION_SUCCESS)
  {
    // Handle error somehow.
    System.out.println('Error: conversion failed due to the following:');
    document.printErrors();
  }
</pre>
<p>
 * Here is an example of using a converter that offers an option. The
 * following code invokes {@link SBMLStripPackageConverter} to remove the
 * SBML Level&nbsp;3 <em>Layout</em> package from a model.  It sets the name
 * of the package to be removed by adding a value for the option named
 * <code>'package'</code> defined by that converter:
 <p>
<pre class='fragment'>
{@link ConversionProperties} config = new {@link ConversionProperties}();
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
  System.out.println('Error: unable to create {@link ConversionProperties} object');
}
</pre>
<p>
 * <h3>Available SBML converters in libSBML</h3>
 <p>
 * LibSBML provides a number of built-in converters; by convention, their
 * names end in <em>Converter</em>. The following are the built-in converters
 * provided by libSBML 5.15.0:
 <p>
 * @copydetails doc_list_of_libsbml_converters
 */

public class SBMLRuleConverter extends SBMLConverter {
   private long swigCPtr;

   protected SBMLRuleConverter(long cPtr, boolean cMemoryOwn)
   {
     super(libsbmlJNI.SBMLRuleConverter_SWIGUpcast(cPtr), cMemoryOwn);
     swigCPtr = cPtr;
   }

   protected static long getCPtr(SBMLRuleConverter obj)
   {
     return (obj == null) ? 0 : obj.swigCPtr;
   }

   protected static long getCPtrAndDisown (SBMLRuleConverter obj)
   {
     long ptr = 0;

     if (obj != null)
     {
       ptr             = obj.swigCPtr;
       obj.swigCMemOwn = false;
     }

     return ptr;
   }

  protected void finalize() {
    delete();
  }

  public synchronized void delete() {
    if (swigCPtr != 0) {
      if (swigCMemOwn) {
        swigCMemOwn = false;
        libsbmlJNI.delete_SBMLRuleConverter(swigCPtr);
      }
      swigCPtr = 0;
    }
    super.delete();
  }


/** * @internal */ public
 static void init() {
    libsbmlJNI.SBMLRuleConverter_init();
  }


/**
   * Creates a new {@link SBMLLevelVersionConverter} object.
   */ public
 SBMLRuleConverter() {
    this(libsbmlJNI.new_SBMLRuleConverter__SWIG_0(), true);
  }


/**
   * Copy constructor; creates a copy of an {@link SBMLLevelVersionConverter}
   * object.
   <p>
   * @param obj the {@link SBMLLevelVersionConverter} object to copy.
   */ public
 SBMLRuleConverter(SBMLRuleConverter obj) {
    this(libsbmlJNI.new_SBMLRuleConverter__SWIG_1(SBMLRuleConverter.getCPtr(obj), obj), true);
  }


/**
   * Creates and returns a deep copy of this {@link SBMLLevelVersionConverter}
   * object.
   <p>
   * @return a (deep) copy of this converter.
   */ public
 SBMLConverter cloneObject() {
    long cPtr = libsbmlJNI.SBMLRuleConverter_cloneObject(swigCPtr, this);
    return (cPtr == 0) ? null : new SBMLRuleConverter(cPtr, true);
  }


/**
   * Returns <code>true</code> if this converter object's properties match the given
   * properties.
   <p>
   * A typical use of this method involves creating a {@link ConversionProperties}
   * object, setting the options desired, and then calling this method on
   * an {@link SBMLLevelVersionConverter} object to find out if the object's
   * property values match the given ones.  This method is also used by
   * {@link SBMLConverterRegistry#getConverterFor(ConversionProperties)}
   * to search across all registered converters for one matching particular
   * properties.
   <p>
   * @param props the properties to match.
   <p>
   * @return <code>true</code> if this converter's properties match, <code>false</code>
   * otherwise.
   */ public
 boolean matchesProperties(ConversionProperties props) {
    return libsbmlJNI.SBMLRuleConverter_matchesProperties(swigCPtr, this, ConversionProperties.getCPtr(props), props);
  }


/**
   * Perform the conversion.
   <p>
   * This method causes the converter to do the actual conversion work,
   * that is, to convert the {@link SBMLDocument} object set by
   * {@link SBMLConverter#setDocument(SBMLDocument)} and
   * with the configuration options set by
   * {@link SBMLConverter#setProperties(ConversionProperties)}.
   <p>
   * <p>
 * @return integer value indicating success/failure of the
 * function.   The possible values
 * returned by this function are:
   * <ul>
   * <li> {@link libsbmlConstants#LIBSBML_OPERATION_SUCCESS LIBSBML_OPERATION_SUCCESS}
   * <li> {@link libsbmlConstants#LIBSBML_INVALID_OBJECT LIBSBML_INVALID_OBJECT}
   * <li> {@link libsbmlConstants#LIBSBML_CONV_INVALID_SRC_DOCUMENT LIBSBML_CONV_INVALID_SRC_DOCUMENT}
   * </ul>
   */ public
 int convert() {
    return libsbmlJNI.SBMLRuleConverter_convert(swigCPtr, this);
  }


/**
   * Returns the default properties of this converter.
   <p>
   * A given converter exposes one or more properties that can be adjusted
   * in order to influence the behavior of the converter.  This method
   * returns the <em>default</em> property settings for this converter.  It is
   * meant to be called in order to discover all the settings for the
   * converter object.
   <p>
   * @return the {@link ConversionProperties} object describing the default properties
   * for this converter.
   */ public
 ConversionProperties getDefaultProperties() {
    return new ConversionProperties(libsbmlJNI.SBMLRuleConverter_getDefaultProperties(swigCPtr, this), true);
  }

}
