/* ----------------------------------------------------------------------------
 * This file was automatically generated by SWIG (http://www.swig.org).
 * Version 3.0.12
 *
 * Do not make changes to this file unless you know what you are doing--modify
 * the SWIG interface file instead.
 * ----------------------------------------------------------------------------- */

package org.sbml.libsbml;

/** 
 *  The trigger expression for an SBML <em>event</em>.
 <p>
 * An {@link Event} object defines when the event can occur, the variables that are
 * affected by the event, and how the variables are affected.  The {@link Trigger}
 * construct in SBML is used to define a mathematical expression that
 * determines when an {@link Event} is <em>triggered</em>.
 <p>
 * A {@link Trigger} object in SBML Level&nbsp;2 and Level&nbsp;3 contains one
 * subelement named 'math' containing a MathML expression.  The expression
 * is evaluated as a value of type <code>boolean.</code>  The exact moment at which
 * the expression evaluates to <code>true</code> is the time point when the {@link Event} is
 * <em>triggered</em>.  In SBML Level&nbsp;3, {@link Trigger} has additional attributes
 * that must be assigned values; they are discussed in a separate section
 * below.
 <p>
 * In SBML Level&nbsp;2 and SBML Level&nbsp;3 Version&nbsp;1, the 'math'
 * subelement is required, and it must evaluate to a <code>boolean</code> expression.
 * In SBML Level&nbsp;3 Version&nbsp;2, those restrictions are relaxed:
 * the 'math' element is optional, and numeric values are allowed in 
 * Boolean contexts (a '0' is interpreted as <code>false</code>, and all other
 * values are interpreted as <code>true</code>).  If a {@link Trigger} with no 'math'
 * is present in an {@link Event}, that {@link Event} will never <em>trigger</em>, unless that
 * missing information is included in an SBML Level&nbsp;3 package.
 <p>
 * An event only <em>triggers</em> when its {@link Trigger} expression makes the
 * transition in value from <code>false</code> to <code>true.</code>  The event will also
 * trigger at any subsequent time points when the trigger makes this
 * transition; in other words, an event can be triggered multiple times
 * during a simulation if its trigger condition makes the transition from
 * <code>false</code> to <code>true</code> more than once.  In SBML Level&nbsp;3, the behavior
 * at the very start of simulation (i.e., at <em>t = 0</em>, where
 * <em>t</em> stands for time) is determined in part by the boolean flag
 * 'initialValue'.  This and other additional features introduced in SBML
 * Level&nbsp;3 are discussed further below.
 <p>
 * <h2>Version differences</h2>
 <p>
 * SBML Level&nbsp;3 Version&nbsp;1 introduces two required attributes
 * on the {@link Trigger} object: 'persistent' and 'initialValue'.  The rest of
 * this introduction describes these two attributes.
 <p>
 * <h3>The 'persistent' attribute on {@link Trigger}</h3>
 <p>
 * In the interval between when an {@link Event} object <em>triggers</em> (i.e.,
 * its {@link Trigger} object expression transitions in value from <code>false</code> to
 * <code>true</code>) and when its assignments are to be <em>executed</em>, conditions
 * in the model may change such that the trigger expression transitions
 * back from <code>true</code> to <code>false.</code>  Should the event's assignments still be
 * made if this happens?  Answering this question is the purpose of the
 * 'persistent' attribute on {@link Trigger}.
 <p>
 * If the boolean attribute 'persistent' has a value of <code>true</code>, then once
 * the event is triggered, all of its assignments are always performed when
 * the time of execution is reached.  The name <em>persistent</em> is meant to
 * evoke the idea that the trigger expression does not have to be
 * re-checked after it triggers if 'persistent'=<code>true.</code>  Conversely, if
 * the attribute value is <code>false</code>, then the trigger expression is not
 * assumed to persist: if the expression transitions in value back to
 * <code>false</code> at any time between when the event triggered and when it is to be
 * executed, the event is no longer considered to have triggered and its
 * assignments are not executed.  (If the trigger expression transitions
 * once more to <code>true</code> after that point, then the event is triggered, but
 * this then constitutes a whole new event trigger-and-execute sequence.)
 <p>
 * The 'persistent' attribute can be especially useful when {@link Event} objects
 * contain {@link Delay} objects, but it is relevant even in a model without delays
 * if the model contains two or more events.  As explained in the
 * introduction to this section, the operation of all events in SBML
 * (delayed or not) is conceptually divided into two phases,
 * <em>triggering</em> and <em>execution</em>; however, unless events have
 * priorities associated with them, SBML does not mandate a particular
 * ordering of event execution in the case of simultaneous events.  Models
 * with multiple events can lead to situations where the execution of one
 * event affects another event's trigger expression value.  If that other
 * event has 'persistent'=<code>false</code>, and its trigger expression evaluates to
 * <code>false</code> before it is to be executed, the event must not be executed
 * after all.
 <p>
 * <h3>The 'initialValue' attribute on {@link Trigger}</h3>
 <p>
 * As mentioned above, an event <em>triggers</em> when the mathematical
 * expression in its {@link Trigger} object transitions in value from <code>false</code> to
 * <code>true.</code>  An unanswered question concerns what happens at the start of a
 * simulation: can event triggers make this transition at <em>t = 0</em>,
 * where <em>t</em> stands for time?
 <p>
 * In order to determine whether an event may trigger at <em>t = 0</em>, it
 * is necessary to know what value the {@link Trigger} object's 'math' expression
 * had immediately prior to <em>t = 0</em>.  This starting value of the
 * trigger expression is determined by the value of the boolean attribute
 * 'initialValue'.  A value of <code>true</code> means the trigger expression is
 * taken to have the value <code>true</code> immediately prior to <em>t = 0</em>.  In
 * that case, the trigger cannot transition in value from <code>false</code> to
 * <code>true</code> at the moment simulation begins (because it has the value <code>true</code>
 * both before and after <em>t = 0</em>), and can only make the transition
 * from <code>false</code> to <code>true</code> sometime <em>after</em> <em>t = 0</em>.  (To do
 * that, it would also first have to transition to <code>false</code> before it could
 * make the transition from <code>false</code> back to <code>true.</code>)  Conversely, if
 * 'initialValue'=<code>false</code>, then the trigger expression is assumed to start
 * with the value <code>false</code>, and therefore may trigger at <em>t = 0</em> if
 * the expression evaluates to <code>true</code> at that moment.
 <p>
 * @see Event
 * @see Delay
 * @see EventAssignment
 */

public class Trigger extends SBase {
   private long swigCPtr;

   protected Trigger(long cPtr, boolean cMemoryOwn)
   {
     super(libsbmlJNI.Trigger_SWIGUpcast(cPtr), cMemoryOwn);
     swigCPtr = cPtr;
   }

   protected static long getCPtr(Trigger obj)
   {
     return (obj == null) ? 0 : obj.swigCPtr;
   }

   protected static long getCPtrAndDisown (Trigger obj)
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
        libsbmlJNI.delete_Trigger(swigCPtr);
      }
      swigCPtr = 0;
    }
    super.delete();
  }

  
/**
   * Creates a new {@link Trigger} using the given SBML <code>level</code> and <code>version</code>
   * values.
   <p>
   * @param level a long integer, the SBML Level to assign to this {@link Trigger}.
   <p>
   * @param version a long integer, the SBML Version to assign to this
   * {@link Trigger}.
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
 Trigger(long level, long version) throws org.sbml.libsbml.SBMLConstructorException {
    this(libsbmlJNI.new_Trigger__SWIG_0(level, version), true);
  }

  
/**
   * Creates a new {@link Trigger} using the given {@link SBMLNamespaces} object
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
 Trigger(SBMLNamespaces sbmlns) throws org.sbml.libsbml.SBMLConstructorException {
    this(libsbmlJNI.new_Trigger__SWIG_1(SBMLNamespaces.getCPtr(sbmlns), sbmlns), true);
  }

  
/**
   * Copy constructor; creates a copy of this {@link Trigger}.
   <p>
   * @param orig the object to copy.
   */ public
 Trigger(Trigger orig) throws org.sbml.libsbml.SBMLConstructorException {
    this(libsbmlJNI.new_Trigger__SWIG_2(Trigger.getCPtr(orig), orig), true);
  }

  
/**
   * Creates and returns a deep copy of this {@link Trigger} object.
   <p>
   * @return the (deep) copy of this {@link Trigger} object.
   */ public
 Trigger cloneObject() {
    long cPtr = libsbmlJNI.Trigger_cloneObject(swigCPtr, this);
    return (cPtr == 0) ? null : new Trigger(cPtr, true);
  }

  
/**
   * Get the mathematical formula for the trigger and return it
   * as an AST.
   <p>
   * @return the math of this {@link Trigger}, or <code>null</code> if the math is not set.
   */ public
 ASTNode getMath() {
    long cPtr = libsbmlJNI.Trigger_getMath(swigCPtr, this);
    return (cPtr == 0) ? null : new ASTNode(cPtr, false);
  }

  
/**
   * (SBML Level&nbsp;3 only) Get the value of the 'initialValue' attribute
   * of this {@link Trigger}.
   <p>
   * @return the boolean value stored as the 'initialValue' attribute value
   * in this {@link Trigger}.
   <p>
   * @note The attribute 'initialValue' is available in SBML Level&nbsp;3,
   * but is not present in lower Levels of SBML.
   */ public
 boolean getInitialValue() {
    return libsbmlJNI.Trigger_getInitialValue(swigCPtr, this);
  }

  
/**
   * (SBML Level&nbsp;3 only) Get the value of the 'persistent' attribute
   * of this {@link Trigger}.
   <p>
   * @return the boolean value stored as the 'persistent' attribute value
   * in this {@link Trigger}.
   <p>
   * @note The attribute 'persistent' is available in SBML Level&nbsp;3,
   * but is not present in lower Levels of SBML.
   */ public
 boolean getPersistent() {
    return libsbmlJNI.Trigger_getPersistent(swigCPtr, this);
  }

  
/**
   * Predicate to test whether the math for this trigger is set.
   <p>
   * @return <code>true</code> if the formula (meaning the 'math' subelement) of
   * this {@link Trigger} is set, <code>false</code> otherwise.
   */ public
 boolean isSetMath() {
    return libsbmlJNI.Trigger_isSetMath(swigCPtr, this);
  }

  
/**
   * (SBML Level&nbsp;3 only) Predicate to test whether the 'initialValue'
   * attribute for this trigger is set.
   <p>
   * @return <code>true</code> if the initialValue attribute of
   * this {@link Trigger} is set, <code>false</code> otherwise.
   <p>
   * @note The attribute 'initialValue' is available in SBML Level&nbsp;3,
   * but is not present in lower Levels of SBML.
   */ public
 boolean isSetInitialValue() {
    return libsbmlJNI.Trigger_isSetInitialValue(swigCPtr, this);
  }

  
/**
   * (SBML Level&nbsp;3 only) Predicate to test whether the 'persistent'
   * attribute for this trigger is set.
   <p>
   * @return <code>true</code> if the persistent attribute of
   * this {@link Trigger} is set, <code>false</code> otherwise.
   <p>
   * @note The attribute 'persistent' is available in SBML Level&nbsp;3,
   * but is not present in lower Levels of SBML.
   */ public
 boolean isSetPersistent() {
    return libsbmlJNI.Trigger_isSetPersistent(swigCPtr, this);
  }

  
/**
   * Sets the trigger expression of this {@link Trigger} instance to a copy of the given
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
    return libsbmlJNI.Trigger_setMath(swigCPtr, this, ASTNode.getCPtr(math), math);
  }

  
/**
   * (SBML Level&nbsp;3 only) Sets the 'initialValue' attribute of this {@link Trigger} instance.
   <p>
   * @param initialValue a boolean representing the initialValue to be set.
   <p>
   * <p>
 * @return integer value indicating success/failure of the
 * function.   The possible values
 * returned by this function are:
   * <ul>
   * <li> {@link libsbmlConstants#LIBSBML_OPERATION_SUCCESS LIBSBML_OPERATION_SUCCESS}
   * <li> {@link libsbmlConstants#LIBSBML_UNEXPECTED_ATTRIBUTE LIBSBML_UNEXPECTED_ATTRIBUTE}
   *
   * </ul> <p>
   * @note The attribute 'initialValue' is available in SBML Level&nbsp;3,
   * but is not present in lower Levels of SBML.
   */ public
 int setInitialValue(boolean initialValue) {
    return libsbmlJNI.Trigger_setInitialValue(swigCPtr, this, initialValue);
  }

  
/**
   * (SBML Level&nbsp;3 only) Sets the 'persistent' attribute of this {@link Trigger} instance.
   <p>
   * @param persistent a boolean representing the persistent value to be set.
   <p>
   * <p>
 * @return integer value indicating success/failure of the
 * function.   The possible values
 * returned by this function are:
   * <ul>
   * <li> {@link libsbmlConstants#LIBSBML_OPERATION_SUCCESS LIBSBML_OPERATION_SUCCESS}
   * <li> {@link libsbmlConstants#LIBSBML_UNEXPECTED_ATTRIBUTE LIBSBML_UNEXPECTED_ATTRIBUTE}
   *
   * </ul> <p>
   * @note The attribute 'persistent' is available in SBML Level&nbsp;3,
   * but is not present in lower Levels of SBML.
   */ public
 int setPersistent(boolean persistent) {
    return libsbmlJNI.Trigger_setPersistent(swigCPtr, this, persistent);
  }

  
/**
   * (SBML Level&nbsp;3 only) Unsets the 'initialValue' attribute of this 
   * {@link Trigger} instance.
   <p>
   * <p>
 * @return integer value indicating success/failure of the
 * function.   The possible values
 * returned by this function are:
   * <ul>
   * <li> {@link libsbmlConstants#LIBSBML_OPERATION_SUCCESS LIBSBML_OPERATION_SUCCESS}
   * <li> {@link libsbmlConstants#LIBSBML_UNEXPECTED_ATTRIBUTE LIBSBML_UNEXPECTED_ATTRIBUTE}
   *
   * </ul> <p>
   * @note The attribute 'initialValue' is available in SBML Level&nbsp;3,
   * but is not present in lower Levels of SBML.
   */ public
 int unsetInitialValue() {
    return libsbmlJNI.Trigger_unsetInitialValue(swigCPtr, this);
  }

  
/**
   * (SBML Level&nbsp;3 only) Unsets the 'persistent' attribute of this 
   * {@link Trigger} instance.
   <p>
   * <p>
 * @return integer value indicating success/failure of the
 * function.   The possible values
 * returned by this function are:
   * <ul>
   * <li> {@link libsbmlConstants#LIBSBML_OPERATION_SUCCESS LIBSBML_OPERATION_SUCCESS}
   * <li> {@link libsbmlConstants#LIBSBML_UNEXPECTED_ATTRIBUTE LIBSBML_UNEXPECTED_ATTRIBUTE}
   *
   * </ul> <p>
   * @note The attribute 'persistent' is available in SBML Level&nbsp;3,
   * but is not present in lower Levels of SBML.
   */ public
 int unsetPersistent() {
    return libsbmlJNI.Trigger_unsetPersistent(swigCPtr, this);
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
 * The exception to this is lists:  all SBML-style list elements have the type 
 * {@link libsbmlConstants#SBML_LIST_OF SBML_LIST_OF}, regardless of what package they 
 * are from.
   <p>
   * @return the SBML type code for this object:
   * {@link libsbmlConstants#SBML_TRIGGER SBML_TRIGGER} (default).
   <p>
   * <p>
 * @warning <span class='warning'>The specific integer values of the possible
 * type codes may be reused by different libSBML plug-ins for SBML Level&nbsp;3.
 * packages,  To fully identify the correct code, <strong>it is necessary to
 * invoke both getPackageName() and getTypeCode()</strong> (or 
 * {@link ListOf#getItemTypeCode()}).</span>
   <p>
   * @see #getElementName()
   * @see #getPackageName()
   */ public
 int getTypeCode() {
    return libsbmlJNI.Trigger_getTypeCode(swigCPtr, this);
  }

  
/**
   * Returns the XML element name of this object, which for {@link Trigger}, is
   * always <code>'trigger'.</code>
   <p>
   * @return the name of this element, i.e., <code>'trigger'.</code> 
   */ public
 String getElementName() {
    return libsbmlJNI.Trigger_getElementName(swigCPtr, this);
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
    libsbmlJNI.Trigger_renameSIdRefs(swigCPtr, this, oldid, newid);
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
    libsbmlJNI.Trigger_renameUnitSIdRefs(swigCPtr, this, oldid, newid);
  }

  
/** * @internal */ public
 void replaceSIDWithFunction(String id, ASTNode function) {
    libsbmlJNI.Trigger_replaceSIDWithFunction(swigCPtr, this, id, ASTNode.getCPtr(function), function);
  }

  
/**
   * Predicate returning <code>true</code> if
   * all the required elements for this {@link Trigger} object
   * have been set.
   <p>
   * @note The required elements for a {@link Trigger} object are:
   * <ul>
   * <li> 'math' inSBML Level&nbsp;2 and Level&nbsp;3 Version&nbsp;1.  
   *     (In SBML Level&nbsp;3 Version&nbsp;2+, it is no longer required.)
   *
   * </ul> <p>
   * @return a boolean value indicating whether all the required
   * elements for this object have been defined.
   */ public
 boolean hasRequiredElements() {
    return libsbmlJNI.Trigger_hasRequiredElements(swigCPtr, this);
  }

  
/**
   * Predicate returning <code>true</code> if
   * all the required attributes for this {@link Trigger} object
   * have been set.
   <p>
   * The required attributes for a {@link Trigger} object are:
   * <ul>
   * <li> 'persistent' (required in SBML Level&nbsp;3)
   * <li> 'initialValue' (required in SBML Level&nbsp;3)
   *
   * </ul> <p>
   * @return a boolean value indicating whether all the required
   * attributes for this object have been defined.
   */ public
 boolean hasRequiredAttributes() {
    return libsbmlJNI.Trigger_hasRequiredAttributes(swigCPtr, this);
  }

  
/**
   * Finds this {@link Trigger}'s {@link Event} parent and calls unsetTrigger() on it, indirectly deleting itself.  Overridden from the {@link SBase} function since the parent is not a {@link ListOf}.
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
    return libsbmlJNI.Trigger_removeFromParentAndDelete(swigCPtr, this);
  }

}
