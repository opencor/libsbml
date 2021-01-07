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
@htmlinclude pkg-marker-core.html An SBML <em>constraint</em>, for stating validity assumptions.
 *
 * The Constraint object class was introduced in SBML Level&nbsp;2
 * Version&nbsp;2 as a mechanism for stating the assumptions under which a
 * model is designed to operate.  The <em>constraints</em> are statements
 * about permissible values of different quantities in a model.
 * Constraints are not used to compute dynamical values for simulation or
 * analysis, but rather, they serve an advisory role for
 * simulation/analysis tools.
 *
 * SBML's Constraint object class has one required attribute, 'id', to
 * give the parameter a unique identifier by which other parts of an SBML
 * model definition can refer to it.  A Constraint object can also have an
 * optional 'name' attribute of type @c string.  Identifiers and names must
 * be used according to the guidelines described in the SBML specification
 * (e.g., Section 3.3 in the Level&nbsp;2 Version 4 specification).  
 *
 * Constraint has one subelement, 'math', containing a MathML
 * formula defining the condition of the constraint.  This formula will
 * return a Boolean value of @c true when the model is a <em>valid</em>
 * state.  The formula can be an arbitrary expression referencing the
 * variables and other entities in an SBML model.  The evaluation of 'math'
 * and behavior of constraints are described in more detail below.
 *
 * In SBML Level&nbsp;2 and SBML Level&nbsp;3 Version&nbsp;1, the 'math'
 * subelement is required, and its formula must be a Boolean value.  In
 * SBML Level&nbsp;3 Version&nbsp;2, these restrictions were relaxed:
 * the 'math' subelement is optional, and numeric values are allowed
 * in Boolean contexts (a '0' is interpreted as @c false, and all other
 * values are interpreted as @c true).  If a Constraint with no 'math'
 * is present in a Model, no restriction on the Model's behavior is
 * implied or enforced.
 *
 * A Constraint structure also has an optional subelement called 'message'.
 * This can contain a message in XHTML format that may be displayed to the
 * user when the condition of the formula in the 'math' subelement
 * evaluates to a value of @c false.  Software tools are not required to
 * display the message, but it is recommended that they do so as a matter
 * of best practice.  The XHTML content within a 'message' subelement must
 * follow the same restrictions as for the 'notes' element on SBase
 * described in in the SBML Level&nbsp;2 specification; please consult the
 * <a target='_blank' href='http://sbml.org/Documents/Specifications'>SBML
 * specification document</a> corresponding to the SBML Level and Version
 * of your model for more information about the requirements for 'notes'
 * content.
 *
 * Constraint was introduced in SBML Level&nbsp;2 Version&nbsp;2.  It is
 * not available in earlier versions of Level&nbsp;2 nor in any version of
 * Level&nbsp;1.
 *
 * @section constraint-semantics Semantics of Constraints
 * 
 * In the context of a simulation, a Constraint has effect at all times
 * <em>t >= 0</em>.  Each Constraint's 'math' subelement is first
 * evaluated after any InitialAssignment definitions in a model at <em>t =
 * 0</em> and can conceivably trigger at that point.  (In other words, a
 * simulation could fail a constraint immediately.)
 *
 * Constraint structures <em>cannot and should not</em> be used to compute
 * the dynamical behavior of a model as part of, for example, simulation.
 * Constraints may be used as input to non-dynamical analysis, for instance
 * by expressing flux constraints for flux balance analysis.
 *
 * The results of a simulation of a model containing a constraint are
 * invalid from any simulation time at and after a point when the function
 * given by the 'math' subelement returns a value of @c false.  Invalid
 * simulation results do not make a prediction of the behavior of the
 * biochemical reaction network represented by the model.  The precise
 * behavior of simulation tools is left undefined with respect to
 * constraints.  If invalid results are detected with respect to a given
 * constraint, the 'message' subelement may optionally be displayed to the
 * user.  The simulation tool may also halt the simulation or clearly
 * delimit in output data the simulation time point at which the simulation
 * results become invalid.
 *
 * SBML does not impose restrictions on duplicate Constraint definitions or
 * the order of evaluation of Constraint objects in a model.  It is
 * possible for a model to define multiple constraints all with the same
 * mathematical expression.  Since the failure of any constraint indicates
 * that the model simulation has entered an invalid state, a system is not
 * required to attempt to detect whether other constraints in the model
 * have failed once any one constraint has failed.
 *
 * 
 *
 */

public class Constraint : SBase {
	private HandleRef swigCPtr;
	
	internal Constraint(IntPtr cPtr, bool cMemoryOwn) : base(libsbmlPINVOKE.Constraint_SWIGUpcast(cPtr), cMemoryOwn)
	{
		//super(libsbmlPINVOKE.ConstraintUpcast(cPtr), cMemoryOwn);
		swigCPtr = new HandleRef(this, cPtr);
	}
	
	internal static HandleRef getCPtr(Constraint obj)
	{
		return (obj == null) ? new HandleRef(null, IntPtr.Zero) : obj.swigCPtr;
	}
	
	internal static HandleRef getCPtrAndDisown (Constraint obj)
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
          libsbmlPINVOKE.delete_Constraint(swigCPtr);
        }
        swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
      }
      base.Dispose(disposing);
    }
  }

  
/**
   * Creates a new Constraint using the given SBML @p level and @p version
   * values.
   *
   * @param level a long integer, the SBML Level to assign to this Constraint.
   *
   * @param version a long integer, the SBML Version to assign to this
   * Constraint.
   *
   *
 * @throws SBMLConstructorException
 * Thrown if the given @p level and @p version combination are invalid
 * or if this object is incompatible with the given level and version.
 *
 *
   *
   *
 * @note Attempting to add an object to an SBMLDocument having a different
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
 * SBMLDocument), knowledge of the intented SBML Level and Version help
 * libSBML determine such things as whether it is valid to assign a
 * particular value to an attribute.
 *
 *
   */ public
 Constraint(long level, long version) : this(libsbmlPINVOKE.new_Constraint__SWIG_0(level, version), true) {
    if (libsbmlPINVOKE.SWIGPendingException.Pending) throw libsbmlPINVOKE.SWIGPendingException.Retrieve();
  }

  
/**
   * Creates a new Constraint using the given SBMLNamespaces object
   * @p sbmlns.
   *
   *
 * 
 * The SBMLNamespaces object encapsulates SBML Level/Version/namespaces
 * information.  It is used to communicate the SBML Level, Version, and (in
 * Level&nbsp;3) packages used in addition to SBML Level&nbsp;3 Core.  A
 * common approach to using libSBML's SBMLNamespaces facilities is to create an
 * SBMLNamespaces object somewhere in a program once, then hand that object
 * as needed to object constructors that accept SBMLNamespaces as arguments.
 *
 *
   *
   * @param sbmlns an SBMLNamespaces object.
   *
   *
 * @throws SBMLConstructorException
 * Thrown if the given @p sbmlns is inconsistent or incompatible
 * with this object.
 *
 *
   *
   *
 * @note Attempting to add an object to an SBMLDocument having a different
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
 * SBMLDocument), knowledge of the intented SBML Level and Version help
 * libSBML determine such things as whether it is valid to assign a
 * particular value to an attribute.
 *
 *
   */ public
 Constraint(SBMLNamespaces sbmlns) : this(libsbmlPINVOKE.new_Constraint__SWIG_1(SBMLNamespaces.getCPtr(sbmlns)), true) {
    if (libsbmlPINVOKE.SWIGPendingException.Pending) throw libsbmlPINVOKE.SWIGPendingException.Retrieve();
  }

  
/**
   * Copy constructor; creates a copy of this Constraint.
   *
   * @param orig the object to copy.
   */ public
 Constraint(Constraint orig) : this(libsbmlPINVOKE.new_Constraint__SWIG_2(Constraint.getCPtr(orig)), true) {
    if (libsbmlPINVOKE.SWIGPendingException.Pending) throw libsbmlPINVOKE.SWIGPendingException.Retrieve();
  }

  
/**
   * Creates and returns a deep copy of this Constraint object.
   *
   * @return the (deep) copy of this Constraint object.
   */ public new
 Constraint clone() {
    global::System.IntPtr cPtr = libsbmlPINVOKE.Constraint_clone(swigCPtr);
    Constraint ret = (cPtr == global::System.IntPtr.Zero) ? null : new Constraint(cPtr, true);
    return ret;
  }

  
/**
   * Get the message, if any, associated with this Constraint
   * 
   * @return the message for this Constraint, as an XMLNode.
   */ public
 XMLNode getMessage() {
    global::System.IntPtr cPtr = libsbmlPINVOKE.Constraint_getMessage(swigCPtr);
    XMLNode ret = (cPtr == global::System.IntPtr.Zero) ? null : new XMLNode(cPtr, false);
    return ret;
  }

  
/**
   * Get the message string, if any, associated with this Constraint
   * 
   * @return the message for this Constraint, as a string.
   */ public new
 string getMessageString() {
    string ret = libsbmlPINVOKE.Constraint_getMessageString(swigCPtr);
    return ret;
  }

  
/**
   * Get the mathematical expression of this Constraint
   * 
   * @return the math for this Constraint, as an ASTNode, or @c null if the math is not set.
   */ public new
 ASTNode getMath() {
    global::System.IntPtr cPtr = libsbmlPINVOKE.Constraint_getMath(swigCPtr);
    ASTNode ret = (cPtr == global::System.IntPtr.Zero) ? null : new ASTNode(cPtr, false);
    return ret;
  }

  
/**
   * Predicate returning @c true if a
   * message is defined for this Constraint.
   *
   * @return @c true if the message of this Constraint is set,
   * @c false otherwise.
   */ public
 bool isSetMessage() {
    bool ret = libsbmlPINVOKE.Constraint_isSetMessage(swigCPtr);
    return ret;
  }

  
/**
   * Predicate returning @c true if a
   * mathematical formula is defined for this Constraint.
   *
   * @return @c true if the 'math' subelement for this Constraint is
   * set, @c false otherwise.
   */ public
 bool isSetMath() {
    bool ret = libsbmlPINVOKE.Constraint_isSetMath(swigCPtr);
    return ret;
  }

  
/**
   * Sets the message of this Constraint.
   *
   * The XMLNode tree passed in @p xhtml is copied.
   *
   * @param xhtml an XML tree containing XHTML content.
   *
   *
 * @return integer value indicating success/failure of the
 * function.  @if clike The value is drawn from the
 * enumeration #OperationReturnValues_t. @endif The possible values
 * returned by this function are:
 * @li @link libsbml#LIBSBML_OPERATION_SUCCESS LIBSBML_OPERATION_SUCCESS@endlink
   * @li @link libsbml#LIBSBML_INVALID_OBJECT LIBSBML_INVALID_OBJECT@endlink
   */ public
 int setMessage(XMLNode xhtml) {
    int ret = libsbmlPINVOKE.Constraint_setMessage__SWIG_0(swigCPtr, XMLNode.getCPtr(xhtml));
    return ret;
  }

  
/**
   * Sets the message of this Constraint.
   *
   * @param message an XML string that is to be used as the content of the
   * 'message' subelement of this object.
   *
   * @param addXHTMLMarkup a boolean indicating whether to wrap the contents
   * of the @p message argument with XHTML paragraph (<code>&lt;p&gt;</code>)
   * tags.  This is appropriate when the string in @p message does not already
   * containg the appropriate XHTML markup.
   *
   *
 * @return integer value indicating success/failure of the
 * function.  @if clike The value is drawn from the
 * enumeration #OperationReturnValues_t. @endif The possible values
 * returned by this function are:
 * @li @link libsbml#LIBSBML_OPERATION_SUCCESS LIBSBML_OPERATION_SUCCESS@endlink
   * @li @link libsbml#LIBSBML_INVALID_OBJECT LIBSBML_INVALID_OBJECT@endlink
   */ public new
 int setMessage(string message, bool addXHTMLMarkup) {
    int ret = libsbmlPINVOKE.Constraint_setMessage__SWIG_1(swigCPtr, message, addXHTMLMarkup);
    if (libsbmlPINVOKE.SWIGPendingException.Pending) throw libsbmlPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  
/**
   * Sets the message of this Constraint.
   *
   * @param message an XML string that is to be used as the content of the
   * 'message' subelement of this object.
   *
   * @param addXHTMLMarkup a boolean indicating whether to wrap the contents
   * of the @p message argument with XHTML paragraph (<code>&lt;p&gt;</code>)
   * tags.  This is appropriate when the string in @p message does not already
   * containg the appropriate XHTML markup.
   *
   *
 * @return integer value indicating success/failure of the
 * function.  @if clike The value is drawn from the
 * enumeration #OperationReturnValues_t. @endif The possible values
 * returned by this function are:
 * @li @link libsbml#LIBSBML_OPERATION_SUCCESS LIBSBML_OPERATION_SUCCESS@endlink
   * @li @link libsbml#LIBSBML_INVALID_OBJECT LIBSBML_INVALID_OBJECT@endlink
   */ public new
 int setMessage(string message) {
    int ret = libsbmlPINVOKE.Constraint_setMessage__SWIG_2(swigCPtr, message);
    if (libsbmlPINVOKE.SWIGPendingException.Pending) throw libsbmlPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  
/**
   * Sets the mathematical expression of this Constraint to a copy of the
   * AST given as @p math.
   *
   * @param math an ASTNode expression to be assigned as the 'math'
   * subelement of this Constraint.
   *
   *
 * @return integer value indicating success/failure of the
 * function.  @if clike The value is drawn from the
 * enumeration #OperationReturnValues_t. @endif The possible values
 * returned by this function are:
 * @li @link libsbml#LIBSBML_OPERATION_SUCCESS LIBSBML_OPERATION_SUCCESS@endlink
   * @li @link libsbml#LIBSBML_INVALID_OBJECT LIBSBML_INVALID_OBJECT@endlink
   */ public new
 int setMath(ASTNode math) {
    int ret = libsbmlPINVOKE.Constraint_setMath(swigCPtr, ASTNode.getCPtr(math));
    return ret;
  }

  
/**
   * Unsets the 'message' subelement of this Constraint.
   *
   *
 * @return integer value indicating success/failure of the
 * function.  @if clike The value is drawn from the
 * enumeration #OperationReturnValues_t. @endif The possible values
 * returned by this function are:
 * @li @link libsbml#LIBSBML_OPERATION_SUCCESS LIBSBML_OPERATION_SUCCESS@endlink
   * @li @link libsbml#LIBSBML_OPERATION_FAILED LIBSBML_OPERATION_FAILED@endlink
   */ public
 int unsetMessage() {
    int ret = libsbmlPINVOKE.Constraint_unsetMessage(swigCPtr);
    return ret;
  }

  
/**
   *
 * Replaces all uses of a given @c SIdRef type attribute value with another
 * value.
 *
 *
 * 

 * In SBML, object identifiers are of a data type called <code>SId</code>.
 * In SBML Level&nbsp;3, an explicit data type called <code>SIdRef</code> was
 * introduced for attribute values that refer to <code>SId</code> values; in
 * previous Levels of SBML, this data type did not exist and attributes were
 * simply described to as 'referring to an identifier', but the effective
 * data type was the same as <code>SIdRef</code> in Level&nbsp;3.  These and
 * other methods of libSBML refer to the type <code>SIdRef</code> for all
 * Levels of SBML, even if the corresponding SBML specification did not
 * explicitly name the data type.
 *
 *
 *
 * This method works by looking at all attributes and (if appropriate)
 * mathematical formulas in MathML content, comparing the referenced
 * identifiers to the value of @p oldid.  If any matches are found, the
 * matching values are replaced with @p newid.  The method does @em not
 * descend into child elements.
 *
 * @param oldid the old identifier.
 * @param newid the new identifier.
 *
 *
   */ public new
 void renameSIdRefs(string oldid, string newid) {
    libsbmlPINVOKE.Constraint_renameSIdRefs(swigCPtr, oldid, newid);
    if (libsbmlPINVOKE.SWIGPendingException.Pending) throw libsbmlPINVOKE.SWIGPendingException.Retrieve();
  }

  
/**
   *
 * Replaces all uses of a given @c UnitSIdRef type attribute value with
 * another value.
 *
 *
 * 
 * In SBML, unit definitions have identifiers of type <code>UnitSId</code>.  In
 * SBML Level&nbsp;3, an explicit data type called <code>UnitSIdRef</code> was
 * introduced for attribute values that refer to <code>UnitSId</code> values; in
 * previous Levels of SBML, this data type did not exist and attributes were
 * simply described to as 'referring to a unit identifier', but the effective
 * data type was the same as <code>UnitSIdRef</code> in Level&nbsp;3.  These and
 * other methods of libSBML refer to the type <code>UnitSIdRef</code> for all
 * Levels of SBML, even if the corresponding SBML specification did not
 * explicitly name the data type.
 *
 *
 *
 * This method works by looking at all unit identifier attribute values
 * (including, if appropriate, inside mathematical formulas), comparing the
 * referenced unit identifiers to the value of @p oldid.  If any matches
 * are found, the matching values are replaced with @p newid.  The method
 * does @em not descend into child elements.
 *
 * @param oldid the old identifier.
 * @param newid the new identifier.
 *
 *
   */ public new
 void renameUnitSIdRefs(string oldid, string newid) {
    libsbmlPINVOKE.Constraint_renameUnitSIdRefs(swigCPtr, oldid, newid);
    if (libsbmlPINVOKE.SWIGPendingException.Pending) throw libsbmlPINVOKE.SWIGPendingException.Retrieve();
  }

  
/** */ /* libsbml-internal */ public new
 void replaceSIDWithFunction(string id, ASTNode function) {
    libsbmlPINVOKE.Constraint_replaceSIDWithFunction(swigCPtr, id, ASTNode.getCPtr(function));
    if (libsbmlPINVOKE.SWIGPendingException.Pending) throw libsbmlPINVOKE.SWIGPendingException.Retrieve();
  }

  
/**
   * Returns the libSBML type code for this SBML object.
   * 
   *
 * 
 * LibSBML attaches an identifying code to every kind of SBML object.  These
 * are integer constants known as <em>SBML type codes</em>.  The names of all
 * the codes begin with the characters <code>SBML_</code>.
 * @if clike The set of possible type codes for core elements is defined in
 * the enumeration #SBMLTypeCode_t, and in addition, libSBML plug-ins for
 * SBML Level&nbsp;3 packages define their own extra enumerations of type
 * codes (e.g., #SBMLLayoutTypeCode_t for the Level&nbsp;3 Layout
 * package).@endif@if java In the Java language interface for libSBML, the
 * type codes are defined as static integer constants in the interface class
 * {@link libsbmlConstants}.  @endif@if python In the Python language
 * interface for libSBML, the type codes are defined as static integer
 * constants in the interface class @link libsbml@endlink.@endif@if csharp In
 * the C# language interface for libSBML, the type codes are defined as
 * static integer constants in the interface class
 * @link libsbmlcs.libsbml@endlink.@endif  Note that different Level&nbsp;3
 * package plug-ins may use overlapping type codes; to identify the package
 * to which a given object belongs, call the 
 * <code>@if conly SBase_getPackageName()
 * @else SBase::getPackageName()
 * @endif</code>
 * method on the object.
 *
 * The exception to this is lists:  all SBML-style list elements have the type 
 * @link libsbml#SBML_LIST_OF SBML_LIST_OF@endlink, regardless of what package they 
 * are from.
 *
 *
   *
   * @return the SBML type code for this object:
   * @link libsbml#SBML_CONSTRAINT SBML_CONSTRAINT@endlink (default).
   *
   *
 * @warning <span class='warning'>The specific integer values of the possible
 * type codes may be reused by different libSBML plug-ins for SBML Level&nbsp;3.
 * packages,  To fully identify the correct code, <strong>it is necessary to
 * invoke both getPackageName() and getTypeCode()</strong> (or 
 * ListOf::getItemTypeCode()).</span>
 *
 *
   *
   * @see getElementName()
   * @see getPackageName()
   */ public new
 int getTypeCode() {
    int ret = libsbmlPINVOKE.Constraint_getTypeCode(swigCPtr);
    return ret;
  }

  
/**
   * Returns the XML element name of this object, which for Constraint, is
   * always @c 'constraint'.
   * 
   * @return the name of this element, i.e., @c 'constraint'.
   */ public new
 string getElementName() {
    string ret = libsbmlPINVOKE.Constraint_getElementName(swigCPtr);
    return ret;
  }

  
/**
   * Predicate returning @c true if
   * all the required elements for this Constraint object
   * have been set.
   *
   * @note The required elements for a Constraint object are:
   * @li 'math' (through SBML Level&nbsp;3 Version&nbsp;1 only; not 
   *     required in Level&nbsp;3 Version&nbsp;2+.)
   *
   * @return a boolean value indicating whether all the required
   * elements for this object have been defined.
   */ public new
 bool hasRequiredElements() {
    bool ret = libsbmlPINVOKE.Constraint_hasRequiredElements(swigCPtr);
    return ret;
  }

}

}
