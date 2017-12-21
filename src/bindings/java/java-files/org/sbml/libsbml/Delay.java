/* ----------------------------------------------------------------------------
 * This file was automatically generated by SWIG (http://www.swig.org).
 * Version 3.0.12
 *
 * Do not make changes to this file unless you know what you are doing--modify
 * the SWIG interface file instead.
 * ----------------------------------------------------------------------------- */

package org.sbml.libsbml;

/**
 *  A delay on the time of execution of an SBML <em>event</em>.
 <p>
 * An {@link Event} object defines when the event can occur, the variables that
 * are affected by the event, and how the variables are affected.  The
 * effect of the event can optionally be delayed after the occurrence of
 * the condition which invokes it.  An event delay is defined using an
 * object of class {@link Delay}.
 <p>
 * The object class {@link Delay} is derived from {@link SBase} and adds a single
 * subelement called 'math'.  This subelement is used to hold MathML
 * content.  The mathematical formula represented by 'math' must evaluate
 * to a numerical value.  It is used as the length of time between when the
 * event is <em>triggered</em> and when the event's assignments are
 * actually <em>executed</em>.  If no delay is present on a given {@link Event}, a time
 * delay of zero is assumed.
 <p>
 * The expression in 'math' must be evaluated at the time the event is
 * <em>triggered</em>.  The expression must always evaluate to a nonnegative number
 * (otherwise, a nonsensical situation could arise where an event is
 * defined to execute before it is triggered!).
 <p>
 * <h2>The units of the mathematical expression in a {@link Delay}</h2>
 <p>
 * In SBML Level&nbsp;2 versions before Version&nbsp;4, the units of the
 * numerical value computed by the {@link Delay}'s 'math' expression are
 * <em>required</em> to be in units of time, or the model is considered to have a
 * unit consistency error.  In Level&nbsp;2 Version&nbsp;4 as well as SBML
 * Level&nbsp;3, this requirement is relaxed; these
 * specifications only stipulate that the units of the numerical value
 * computed by a {@link Delay} instance's 'math' expression <em>should</em> match the
 * model's units of time (meaning the definition of the <code>time</code> units in
 * the model).  LibSBML respects these requirements, and depending on
 * whether an earlier Version of SBML Level&nbsp;2 is in use, libSBML may
 * or may not flag unit inconsistencies as errors or merely warnings.
 <p>
 * Note that <em>units are not predefined or assumed</em> for the contents
 * of 'math' in a {@link Delay} object; rather, they must be defined explicitly for
 * each instance of a {@link Delay} object in a model.  This is an important point
 * to bear in mind when literal numbers are used in delay expressions.  For
 * example, the following {@link Event} instance would result in a warning logged
 * by {@link SBMLDocument#checkConsistency()} about the fact that libSBML cannot
 * verify the consistency of the units of the expression.  The reason is
 * that the formula inside the 'math' element does not have any declared
 * units, whereas what is expected in this context is units of time:
 * <pre class='fragment'>
&lt;model&gt;
    ...
    &lt;listOfEvents&gt;
        &lt;event useValuesFromTriggerTime='true'&gt;
            ...
            &lt;delay&gt;
                &lt;math xmlns='http://www.w3.org/1998/Math/MathML'&gt;
                    &lt;cn&gt; 1 &lt;/cn&gt;
                &lt;/math&gt;
            &lt;/delay&gt;
            ...
        &lt;/event&gt;
    &lt;/listOfEvents&gt;
    ...
&lt;/model&gt;
</pre>
 <p>
 * The <code>&lt;cn&gt; 1 &lt;/cn&gt;</code> within the mathematical formula
 * of the <code>delay</code> above has <em>no units declared</em>.  To make the
 * expression have the needed units of time, literal numbers should be
 * avoided in favor of defining {@link Parameter} objects for each quantity, and
 * declaring units for the {@link Parameter} values.  The following fragment of
 * SBML illustrates this approach:
 * <pre class='fragment'>
&lt;model&gt;
    ...
    &lt;listOfParameters&gt;
        &lt;parameter id='transcriptionDelay' value='10' units='second'/&gt;
    &lt;/listOfParameters&gt;
    ...
    &lt;listOfEvents&gt;
        &lt;event useValuesFromTriggerTime='true'&gt;
            ...
            &lt;delay&gt;
                &lt;math xmlns='http://www.w3.org/1998/Math/MathML'&gt;
                    &lt;ci&gt; transcriptionDelay &lt;/ci&gt;
                &lt;/math&gt;
            &lt;/delay&gt;
            ...
        &lt;/event&gt;
    &lt;/listOfEvents&gt;
    ...
&lt;/model&gt;
</pre>
 <p>
 * In SBML Level&nbsp;3, an alternative approach is available in the form
 * of the <code>units</code> attribute, which SBML Level&nbsp;3 allows to appear on
 * MathML <code>cn</code> elements.  The value of this attribute can be used to
 * indicate the unit of measurement to be associated with the number in the
 * content of a <code>cn</code> element.  The attribute is named <code>units</code> but,
 * because it appears inside MathML element (which is in the XML namespace
 * for MathML and not the namespace for SBML), it must always be prefixed
 * with an XML namespace prefix for an SBML Level&nbsp;3
 * namespace.  The following is an example of this approach:
 * <pre class='fragment'>
&lt;model timeUnits='second' ...&gt;
    ...
    &lt;listOfEvents&gt;
        &lt;event useValuesFromTriggerTime='true'&gt;
            ...
            &lt;delay&gt;
                &lt;math xmlns='http://www.w3.org/1998/Math/MathML'
                      xmlns:sbml='http://www.sbml.org/sbml/level3/version1/core'&gt;
                    &lt;cn sbml:units='second'&gt; 10 &lt;/cn&gt;
                &lt;/math&gt;
            &lt;/delay&gt;
            ...
        &lt;/event&gt;
    &lt;/listOfEvents&gt;
    ...
&lt;/model&gt;
</pre>
 <p>
 * <h2>Restrictions relaxed in SBML Level&nbsp;3 Version&nbsp;2</h2>
 <p>
 * In SBML Level&nbsp;3 Version&nbsp;2, the requirement that a {@link Delay}
 * have a 'math' subelement was relaxed, making it optional.  In
 * this case, the {@link Delay} remains undefined, and unless that information
 * is provided in some other form (such as with an SBML Level&nbsp;3
 * package), the {@link Event} behaves as if it had no {@link Delay}.
 */

public class Delay extends SBase {
   private long swigCPtr;

   protected Delay(long cPtr, boolean cMemoryOwn)
   {
     super(libsbmlJNI.Delay_SWIGUpcast(cPtr), cMemoryOwn);
     swigCPtr = cPtr;
   }

   protected static long getCPtr(Delay obj)
   {
     return (obj == null) ? 0 : obj.swigCPtr;
   }

   protected static long getCPtrAndDisown (Delay obj)
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
        libsbmlJNI.delete_Delay(swigCPtr);
      }
      swigCPtr = 0;
    }
    super.delete();
  }


/**
   * Creates a new {@link Delay} using the given SBML <code>level</code> and <code>version</code>
   * values.
   <p>
   * @param level a long integer, the SBML Level to assign to this {@link Delay}.
   <p>
   * @param version a long integer, the SBML Version to assign to this
   * {@link Delay}.
   <p>
   * <p>
 * @throws SBMLConstructorException
 * Thrown if the given <code>level</code> and <code>version</code> combination are invalid
 * or if this object is incompatible with the given level and version.
   <p>
   * <p>
 * @note Attempting to add an object to an {@link SBMLDocument} having a different
 * combination of SBML Level, Version and XML namespaces than the object
 * itself will result in an error at the time a caller attempts to make the
 * addition.  A parent object must have compatible Level, Version and XML
 * namespaces.  (Strictly speaking, a parent may also have more XML
 * namespaces than a child, but the reverse is not permitted.)  The
 * restriction is necessary to ensure that an SBML model has a consistent
 * overall structure.  This requires callers to manage their objects
 * carefully, but the benefit is increased flexibility in how models can be
 * created by permitting callers to create objects bottom-up if desired.  In
 * situations where objects are not yet attached to parents (e.g.,
 * {@link SBMLDocument}), knowledge of the intented SBML Level and Version help
 * libSBML determine such things as whether it is valid to assign a
 * particular value to an attribute.
   */ public
 Delay(long level, long version) throws org.sbml.libsbml.SBMLConstructorException {
    this(libsbmlJNI.new_Delay__SWIG_0(level, version), true);
  }


/**
   * Creates a new {@link Delay} using the given {@link SBMLNamespaces} object
   * <code>sbmlns</code>.
   <p>
   * <p>
 * The {@link SBMLNamespaces} object encapsulates SBML Level/Version/namespaces
 * information.  It is used to communicate the SBML Level, Version, and (in
 * Level&nbsp;3) packages used in addition to SBML Level&nbsp;3 Core.  A
 * common approach to using libSBML's {@link SBMLNamespaces} facilities is to create an
 * {@link SBMLNamespaces} object somewhere in a program once, then hand that object
 * as needed to object constructors that accept {@link SBMLNamespaces} as arguments.
   <p>
   * @param sbmlns an {@link SBMLNamespaces} object.
   <p>
   * <p>
 * @throws SBMLConstructorException
 * Thrown if the given <code>sbmlns</code> is inconsistent or incompatible
 * with this object.
   <p>
   * <p>
 * @note Attempting to add an object to an {@link SBMLDocument} having a different
 * combination of SBML Level, Version and XML namespaces than the object
 * itself will result in an error at the time a caller attempts to make the
 * addition.  A parent object must have compatible Level, Version and XML
 * namespaces.  (Strictly speaking, a parent may also have more XML
 * namespaces than a child, but the reverse is not permitted.)  The
 * restriction is necessary to ensure that an SBML model has a consistent
 * overall structure.  This requires callers to manage their objects
 * carefully, but the benefit is increased flexibility in how models can be
 * created by permitting callers to create objects bottom-up if desired.  In
 * situations where objects are not yet attached to parents (e.g.,
 * {@link SBMLDocument}), knowledge of the intented SBML Level and Version help
 * libSBML determine such things as whether it is valid to assign a
 * particular value to an attribute.
   */ public
 Delay(SBMLNamespaces sbmlns) throws org.sbml.libsbml.SBMLConstructorException {
    this(libsbmlJNI.new_Delay__SWIG_1(SBMLNamespaces.getCPtr(sbmlns), sbmlns), true);
  }


/**
   * Copy constructor; creates a copy of this {@link Delay}.
   <p>
   * @param orig the object to copy.
   */ public
 Delay(Delay orig) throws org.sbml.libsbml.SBMLConstructorException {
    this(libsbmlJNI.new_Delay__SWIG_2(Delay.getCPtr(orig), orig), true);
  }


/**
   * Creates and returns a deep copy of this {@link Delay} object.
   <p>
   * @return the (deep) copy of this {@link Delay} object.
   */ public
 Delay cloneObject() {
    long cPtr = libsbmlJNI.Delay_cloneObject(swigCPtr, this);
    return (cPtr == 0) ? null : new Delay(cPtr, true);
  }


/**
   * Get the mathematical formula for the delay and return it
   * as an AST.
   <p>
   * @return the math of this {@link Delay}, or <code>null</code> if the math is not set.
   */ public
 ASTNode getMath() {
    long cPtr = libsbmlJNI.Delay_getMath(swigCPtr, this);
    return (cPtr == 0) ? null : new ASTNode(cPtr, false);
  }


/**
   * Predicate to test whether the formula for this delay is set.
   <p>
   * @return <code>true</code> if the formula (meaning the <code>math</code> subelement) of
   * this {@link Delay} is set, <code>false</code> otherwise.
   */ public
 boolean isSetMath() {
    return libsbmlJNI.Delay_isSetMath(swigCPtr, this);
  }


/**
   * Sets the delay expression of this {@link Delay} instance to a copy of the given
   * {@link ASTNode}.
   <p>
   * @param math an {@link ASTNode} representing a formula tree.
   <p>
   * <p>
 * @return integer value indicating success/failure of the
 * function.   The possible values
 * returned by this function are:
   * <ul>
   * <li> {@link libsbmlConstants#LIBSBML_OPERATION_SUCCESS LIBSBML_OPERATION_SUCCESS}
   * <li> {@link libsbmlConstants#LIBSBML_INVALID_OBJECT LIBSBML_INVALID_OBJECT}
   * </ul>
   */ public
 int setMath(ASTNode math) {
    return libsbmlJNI.Delay_setMath(swigCPtr, this, ASTNode.getCPtr(math), math);
  }


/**
   * Calculates and returns a {@link UnitDefinition} that expresses the units
   * of measurement assumed for the 'math' expression of this {@link Delay}.
   <p>
   * <p>
 * {@link Delay} elements in SBML express a time delay for an {@link Event}.  Beginning
 * with SBML Level&nbsp;2 Version&nbsp;2, the units of that time are
 * calculated based on the mathematical expression and the model quantities
 * referenced by <code>&lt;ci&gt;</code> elements used within that
 * expression.  (In SBML Level&nbsp;2 Version&nbsp;1, there exists an
 * attribute on {@link Event} called 'timeUnits'.  This attribute can be used to set
 * the units of the {@link Delay} expression explicitly.)  The method
 * {@link Delay#getDerivedUnitDefinition()} returns what libSBML computes the units
 * to be, to the extent that libSBML can compute them.
   <p>
   * <p>
 * @note The functionality that facilitates unit analysis depends on the
 * model as a whole.  Thus, in cases where the object has not been added to
 * a model or the model itself is incomplete, unit analysis is not possible
 * and this method will return <code>null.</code>
   <p>
   * <p>
 * @warning <span class='warning'>Note that it is possible the 'math'
 * expression in the {@link Delay} contains literal numbers or parameters with
 * undeclared units.  In those cases, it is not possible to calculate the
 * units of the overall expression without making assumptions.  LibSBML does
 * not make assumptions about the units, and
 * {@link Delay#getDerivedUnitDefinition()} only returns the units as far as it is
 * able to determine them.  For example, in an expression <em>X + Y</em>, if
 * <em>X</em> has unambiguously-defined units and <em>Y</em> does not, it
 * will return the units of <em>X</em>.  When using this method, <strong>it
 * is critical that callers also invoke the method</strong>
 * {@link Delay#containsUndeclaredUnits()} <strong>to determine whether this
 * situation holds</strong>.  Callers should take suitable action in those
 * situations.</span>
   <p>
   * @return a {@link UnitDefinition} that expresses the units of the math
   * expression of this {@link Delay}, or <code>null</code> if one cannot be constructed.
   <p>
   * @see #containsUndeclaredUnits()
   */ public
 UnitDefinition getDerivedUnitDefinition() {
    long cPtr = libsbmlJNI.Delay_getDerivedUnitDefinition__SWIG_0(swigCPtr, this);
    return (cPtr == 0) ? null : new UnitDefinition(cPtr, false);
  }


/**
   * Predicate returning <code>true</code> if the 'math' expression in this {@link Delay}
   * instance contains parameters with undeclared units or literal numbers.
   <p>
   * <p>
 * {@link Delay} elements in SBML express a time delay for an {@link Event}.  Beginning
 * with SBML Level&nbsp;2 Version&nbsp;2, the units of that time are
 * calculated based on the mathematical expression and the model quantities
 * referenced by <code>&lt;ci&gt;</code> elements used within that
 * expression.  (In SBML Level&nbsp;2 Version&nbsp;1, there exists an
 * attribute on {@link Event} called 'timeUnits'.  This attribute can be used to set
 * the units of the {@link Delay} expression explicitly.)  The method
 * {@link Delay#getDerivedUnitDefinition()} returns what libSBML computes the units
 * to be, to the extent that libSBML can compute them.
   <p>
   * If the expression contains literal numbers or parameters with undeclared
   * units, <strong>libSBML may not be able to compute the full units of the
   * expression</strong> and will only return what it can compute.  Callers
   * should always use {@link Delay#containsUndeclaredUnits()} when using
   * {@link Delay#getDerivedUnitDefinition()} to decide whether the returned units
   * may be incomplete.
   <p>
   * @return <code>true</code> if the math expression of this {@link Delay} includes
   * numbers/parameters with undeclared units, <code>false</code> otherwise.
   <p>
   * @note A return value of <code>true</code> indicates that the {@link UnitDefinition}
   * returned by {@link Delay#getDerivedUnitDefinition()} may not accurately
   * represent the units of the expression.
   <p>
   * @see #getDerivedUnitDefinition()
   */ public
 boolean containsUndeclaredUnits() {
    return libsbmlJNI.Delay_containsUndeclaredUnits__SWIG_0(swigCPtr, this);
  }


/**
   * Returns the libSBML type code of this object instance.
   <p>
   * <p>
 * LibSBML attaches an identifying code to every kind of SBML object.  These
 * are integer constants known as <em>SBML type codes</em>.  The names of all
 * the codes begin with the characters <code>SBML_</code>.
 * In the Java language interface for libSBML, the
 * type codes are defined as static integer constants in the interface class
 * {@link libsbmlConstants}.    Note that different Level&nbsp;3
 * package plug-ins may use overlapping type codes; to identify the package
 * to which a given object belongs, call the
 * <code>{@link SBase#getPackageName()}
 * </code>
 * method on the object.
   <p>
   * @return the SBML type code for this object:
   * {@link libsbmlConstants#SBML_DELAY SBML_DELAY} (default).
   <p>
   * <p>
 * @warning <span class='warning'>The specific integer values of the possible
 * type codes may be reused by different libSBML plug-ins for SBML Level&nbsp;3.
 * packages,  To fully identify the correct code, <strong>it is necessary to
 * invoke both getTypeCode() and getPackageName()</strong>.</span>
   <p>
   * @see #getElementName()
   * @see #getPackageName()
   */ public
 int getTypeCode() {
    return libsbmlJNI.Delay_getTypeCode(swigCPtr, this);
  }


/**
   * Returns the XML element name of this object, which for {@link Delay}, is
   * always <code>'delay'.</code>
   <p>
   * @return the name of this element, i.e., <code>'delay'.</code>
   <p>
   * @see #getTypeCode()
   */ public
 String getElementName() {
    return libsbmlJNI.Delay_getElementName(swigCPtr, this);
  }


/**
   * Predicate returning <code>true</code> if
   * all the required elements for this {@link Delay} object
   * have been set.
   <p>
   * @note The required elements for a {@link Delay} object are:
   * <ul>
   * <li> 'math' inSBML Level&nbsp;2 and Level&nbsp;3 Version&nbsp;1.
   *     (In SBML Level&nbsp;3 Version&nbsp;2+, it is no longer required.)
   *
   * </ul> <p>
   * @return a boolean value indicating whether all the required
   * elements for this object have been defined.
   */ public
 boolean hasRequiredElements() {
    return libsbmlJNI.Delay_hasRequiredElements(swigCPtr, this);
  }


/**
   * Finds this {@link Delay}'s {@link Event} parent and calls unsetDelay() on it, indirectly
   * deleting itself.
   <p>
   * Overridden from the {@link SBase} function since the parent is not a {@link ListOf}.
   <p>
   * <p>
 * @return integer value indicating success/failure of the
 * function.   The possible values
 * returned by this function are:
   * <ul>
   * <li> {@link libsbmlConstants#LIBSBML_OPERATION_SUCCESS LIBSBML_OPERATION_SUCCESS}
   * <li> {@link libsbmlConstants#LIBSBML_OPERATION_FAILED LIBSBML_OPERATION_FAILED}
   * </ul>
   */ public
 int removeFromParentAndDelete() {
    return libsbmlJNI.Delay_removeFromParentAndDelete(swigCPtr, this);
  }


/**
   * <p>
 * Replaces all uses of a given <code>SIdRef</code> type attribute value with another
 * value.
 <p>
 * <p>
 * In SBML, object identifiers are of a data type called <code>SId</code>.
 * In SBML Level&nbsp;3, an explicit data type called <code>SIdRef</code> was
 * introduced for attribute values that refer to <code>SId</code> values; in
 * previous Levels of SBML, this data type did not exist and attributes were
 * simply described to as 'referring to an identifier', but the effective
 * data type was the same as <code>SIdRef</code> in Level&nbsp;3.  These and
 * other methods of libSBML refer to the type <code>SIdRef</code> for all
 * Levels of SBML, even if the corresponding SBML specification did not
 * explicitly name the data type.
 <p>
 * This method works by looking at all attributes and (if appropriate)
 * mathematical formulas in MathML content, comparing the referenced
 * identifiers to the value of <code>oldid</code>.  If any matches are found, the
 * matching values are replaced with <code>newid</code>.  The method does <em>not</em>
 * descend into child elements.
 <p>
 * @param oldid the old identifier.
 * @param newid the new identifier.
   */ public
 void renameSIdRefs(String oldid, String newid) {
    libsbmlJNI.Delay_renameSIdRefs(swigCPtr, this, oldid, newid);
  }


/**
   * <p>
 * Replaces all uses of a given <code>UnitSIdRef</code> type attribute value with
 * another value.
 <p>
 * <p>
 * In SBML, unit definitions have identifiers of type <code>UnitSId</code>.  In
 * SBML Level&nbsp;3, an explicit data type called <code>UnitSIdRef</code> was
 * introduced for attribute values that refer to <code>UnitSId</code> values; in
 * previous Levels of SBML, this data type did not exist and attributes were
 * simply described to as 'referring to a unit identifier', but the effective
 * data type was the same as <code>UnitSIdRef</code> in Level&nbsp;3.  These and
 * other methods of libSBML refer to the type <code>UnitSIdRef</code> for all
 * Levels of SBML, even if the corresponding SBML specification did not
 * explicitly name the data type.
 <p>
 * This method works by looking at all unit identifier attribute values
 * (including, if appropriate, inside mathematical formulas), comparing the
 * referenced unit identifiers to the value of <code>oldid</code>.  If any matches
 * are found, the matching values are replaced with <code>newid</code>.  The method
 * does <em>not</em> descend into child elements.
 <p>
 * @param oldid the old identifier.
 * @param newid the new identifier.
   */ public
 void renameUnitSIdRefs(String oldid, String newid) {
    libsbmlJNI.Delay_renameUnitSIdRefs(swigCPtr, this, oldid, newid);
  }


/** * @internal */ public
 void replaceSIDWithFunction(String id, ASTNode function) {
    libsbmlJNI.Delay_replaceSIDWithFunction(swigCPtr, this, id, ASTNode.getCPtr(function), function);
  }

}
