/* ----------------------------------------------------------------------------
 * This file was automatically generated by SWIG (http://www.swig.org).
 * Version 2.0.6
 *
 * Do not make changes to this file unless you know what you are doing--modify
 * the SWIG interface file instead.
 * ----------------------------------------------------------------------------- */

package org.sbml.libsbml;

/**
 *  An SBML <em>rate rule</em> representing <em>dx/dt = f(<b>Y</b>)</em>.
 <p>
 * The rule type {@link RateRule} is derived from the parent class {@link Rule}.  It is
 * used to express equations that determine the rates of change of
 * variables.  The left-hand side (the 'variable' attribute) can refer to
 * the identifier of a species, compartment, or parameter (but not a
 * reaction).  The entity identified must have its 'constant' attribute set
 * to <code>false.</code>  The effects of a {@link RateRule} are in general terms the same,
 * but differ in the precise details depending on which variable is being
 * set:
 <p>
 * <ul> <li> <em>In the case of a species</em>, a {@link RateRule} sets the rate of
 * change of the species' quantity (<em>concentration</em> or <em>amount of
 * substance</em>) to the value determined by the formula in the 'math'
 * subelement of the {@link RateRule} object.  The overall units of the formula in
 * 'math' <em>should</em> (in SBML Level&nbsp;2 Version&nbsp;4 and in SBML Level&nbsp;3) or
 * <em>must</em> (in SBML releases prior to Level&nbsp;2 version&nbsp;4) be equal to
 * the unit of <em>species quantity</em> divided by the model-wide unit of
 * <em>time</em>.  <em>Restrictions</em>: There must not be both a {@link RateRule}
 * 'variable' attribute and a {@link SpeciesReference} 'species' attribute having
 * the same value, unless that species has its 'boundaryCondition'
 * attribute is set to <code>true.</code>  This means a rate rule cannot be defined
 * for a species that is created or destroyed in a reaction, unless that
 * species is defined as a boundary condition in the model.
 <p>
 * <li> (For SBML Level&nbsp;3 only) <em>In the case of a species
 * reference</em>, a {@link RateRule} sets the rate of change of the stoichiometry
 * of the referenced reactant or product to the value determined by the
 * formula in 'math'.  The unit associated with the value produced by the
 * 'math' formula should be consistent with the unit 'dimensionless'
 * divided by the model-wide unit of <em>time</em>.
 <p>
 * <li> <em>In the case of a compartment</em>, a {@link RateRule} sets the rate of
 * change of the compartment's size to the value determined by the formula
 * in the 'math' subelement of the {@link RateRule} object.  The overall units of
 * the formula <em>should</em> (in SBML Level&nbsp;2 Version&nbsp;4 and in SBML
 * Level&nbsp;3) or <em>must</em> (in SBML releases prior to Level&nbsp;2
 * version&nbsp;4) be the units of the compartment's <em>size</em> divided
 * by the model-wide unit of <em>time</em>.
 <p>
 * <li> <em>In the case of a parameter</em>, a {@link RateRule} sets the rate of
 * change of the parameter's value to that determined by the formula in the
 * 'math' subelement of the {@link RateRule} object.  The overall units of the
 * formula <em>should</em> (in SBML Level&nbsp;2 Version&nbsp;4 and in SBML
 * Level&nbsp;3) or <em>must</em> (in SBML releases prior to Level&nbsp;2
 * version&nbsp;4) be the {@link Parameter} object's 'unit' attribute value divided
 * by the model-wide unit of <em>time</em>.
 <p>
 * <li> (For SBML Level&nbsp;3 Version&nbsp;2 only) <em>In the case of
 * an object from an SBML Level&nbsp;3 package</em>, a {@link RateRule} sets the rate
 * of change of the referenced object's value (as defined by that package)
 * to the value of the formula in 'math'.  The unit of measurement associated
 * with the value produced by the formula should be the same as that object's
 * units attribute value (if it has such an attribute) divided by the
 * model-wide unit of <em>time</em>, or be equal to the units of model components
 * of that type (if objects of that class are defined by the package as having
 * the same units) divided by the model-wide unit of <em>time</em>.
 * </ul>
 <p>
 * In SBML Level&nbsp;2 and Level&nbsp;3 Version&nbsp;1, the 'math'
 * subelement of the {@link RateRule} is required.  In SBML Level&nbsp;3
 * Version&nbsp;2, this rule is relaxed, and the subelement is
 * optional.  If a {@link RateRule} with no 'math' child is present in the model,
 * the rate at which its referenced 'variable' changes over time is
 * undefined.  This may represent a situation where the model itself
 * is unfinished, or the missing information may be provided by an
 * SBML Level&nbsp;3 package.
 <p>
 * If the variable attribute of a {@link RateRule} object references an object in
 * an SBML namespace that is not understood by the interpreter reading a
 * given SBML document (that is, if the object is defined by an SBML
 * Level&nbsp;3 package that the software does not support), the rate rule
 * must be ignored--the object's value will not need to be set, as the
 * interpreter could not understand that package. If an interpreter cannot
 * establish whether a referenced object is missing from the model or
 * instead is defined in an SBML namespace not understood by the interpreter,
 * it may produce a warning to the user. (The latter situation may only
 * arise if an SBML package is present in the SBML document with a
 * package:required attribute of 'true'.)
 <p>
 * In the context of a simulation, rate rules are in effect for simulation
 * time <em>t</em> &gt; <em>0</em>.  Please consult the relevant SBML
 * specification for additional information about the semantics of
 * assignments, rules, and entity values for simulation time <em>t</em>
 * &#8804; <em>0</em>.
 <p>
 * As mentioned in the description of {@link AssignmentRule}, a model must not
 * contain more than one {@link RateRule} or {@link AssignmentRule} object having the same
 * value of 'variable'; in other words, in the set of all assignment rules
 * and rate rules in an SBML model, each variable appearing in the
 * left-hand sides can only appear once.  This simply follows from the fact
 * that an indeterminate system would result if a model contained more than
 * one assignment rule for the same variable or both an assignment rule and
 * a rate rule for the same variable.
 <p>
 * <p>
 * <h2>General summary of SBML rules</h2>
 <p>
 * In SBML Level&nbsp;3 as well as Level&nbsp;2, rules are separated into three
 * subclasses for the benefit of model analysis software.  The three
 * subclasses are based on the following three different possible functional
 * forms (where <em>x</em> is a variable, <em>f</em> is some arbitrary
 * function returning a numerical result, <b><em>V</em></b> is a vector of
 * variables that does not include <em>x</em>, and <b><em>W</em></b> is a
 * vector of variables that may include <em>x</em>):
 <p>
 * <table border='0' cellpadding='0' class='centered' style='font-size: small'>
 * <tr><td width='120px'><em>Algebraic:</em></td><td width='250px'>left-hand side is zero</td><td><em>0 = f(<b>W</b>)</em></td></tr>
 * <tr><td><em>Assignment:</em></td><td>left-hand side is a scalar:</td><td><em>x = f(<b>V</b>)</em></td></tr>
 * <tr><td><em>Rate:</em></td><td>left-hand side is a rate-of-change:</td><td><em>dx/dt = f(<b>W</b>)</em></td></tr>
 * </table>
 <p>
 * In their general form given above, there is little to distinguish
 * between <em>assignment</em> and <em>algebraic</em> rules.  They are treated as
 * separate cases for the following reasons:
 <p>
 * <ul>
 * <li> <em>Assignment</em> rules can simply be evaluated to calculate
 * intermediate values for use in numerical methods.  They are statements
 * of equality that hold at all times.  (For assignments that are only
 * performed once, see {@link InitialAssignment}.)
<p>
 * <li> SBML needs to place restrictions on assignment rules, for example
 * the restriction that assignment rules cannot contain algebraic loops.
 <p>
 * <li> Some simulators do not contain numerical solvers capable of solving
 * unconstrained algebraic equations, and providing more direct forms such
 * as assignment rules may enable those simulators to process models they
 * could not process if the same assignments were put in the form of
 * general algebraic equations;
 <p>
 * <li> Those simulators that <em>can</em> solve these algebraic equations make a
 * distinction between the different categories listed above; and
 <p>
 * <li> Some specialized numerical analyses of models may only be applicable
 * to models that do not contain <em>algebraic</em> rules.
 *
 * </ul> <p>
 * The approach taken to covering these cases in SBML is to define an
 * abstract {@link Rule} structure containing a subelement, 'math', to hold the
 * right-hand side expression, then to derive subtypes of {@link Rule} that add
 * attributes to distinguish the cases of algebraic, assignment and rate
 * rules.  The 'math' subelement must contain a MathML expression defining the
 * mathematical formula of the rule.  This MathML formula must return a
 * numerical value.  The formula can be an arbitrary expression referencing
 * the variables and other entities in an SBML model.
 <p>
 * Each of the three subclasses of {@link Rule} (AssignmentRule, {@link AlgebraicRule},
 * {@link RateRule}) inherit the the 'math' subelement and other fields from {@link SBase}.
 * The {@link AssignmentRule} and {@link RateRule} classes add an additional attribute,
 * 'variable'.  See the definitions of {@link AssignmentRule}, {@link AlgebraicRule} and
 * {@link RateRule} for details about the structure and interpretation of each one.
 <p>
 * <h2>Additional restrictions on SBML rules</h2>
 <p>
 * An important design goal of SBML rule semantics is to ensure that a
 * model's simulation and analysis results will not be dependent on when or
 * how often rules are evaluated.  To achieve this, SBML needs to place two
 * restrictions on rule use.  The first concerns algebraic loops in the system
 * of assignments in a model, and the second concerns overdetermined systems.
 <p>
 * <h3>A model must not contain algebraic loops</h3>
 <p>
 * The combined set of {@link InitialAssignment}, {@link AssignmentRule} and {@link KineticLaw}
 * objects in a model constitute a set of assignment statements that should be
 * considered as a whole.  (A {@link KineticLaw} object is counted as an assignment
 * because it assigns a value to the symbol contained in the 'id' attribute of
 * the {@link Reaction} object in which it is defined.)  This combined set of
 * assignment statements must not contain algebraic loops&mdash;dependency
 * chains between these statements must terminate.  To put this more formally,
 * consider a directed graph in which nodes are assignment statements and
 * directed arcs exist for each occurrence of an SBML species, compartment or
 * parameter symbol in an assignment statement's 'math' subelement.  Let the
 * directed arcs point from the statement assigning the symbol to the
 * statements that contain the symbol in their 'math' subelement expressions.
 * This graph must be acyclic.
 <p>
 * Similarly, the combined set of {@link RateRule} and {@link Reaction} objects constitute
 * a set of definitions for the rates of change of various model entities
 * (namely, the objects identified by the values of the 'variable' attributes
 * of the {@link RateRule} objects, and the 'species' attributes of the {@link SpeciesReference}
 * objects in each {@link Reaction}).  In SBML Level&nbsp;3 Version&nbsp;2, these rates
 * of change may be referenced directly
 * using the <em>rateOf</em> csymbol, but may not thereby contain algebraic
 * loops&mdash;dependency chains between these statements must terminate.  More
 * formally, consider a directed graph in which the nodes are the definitions
 * of different variables' rates of change, and directed arcs exist for each
 * occurrence of a variable referenced by a <em>rateOf</em> csymbol from any
 * {@link RateRule} or {@link KineticLaw} object in the model.  Let the directed arcs point
 * from the variable referenced by the <em>rateOf</em> csymbol (call it
 * <em>x</em>) to the variable(s) determined by the 'math' expression in which
 * <em>x</em> appears.  This graph must be acyclic.
 <p>
 * SBML does not specify when or how often rules should be evaluated.
 * Eliminating algebraic loops ensures that assignment statements can be
 * evaluated any number of times without the result of those evaluations
 * changing.  As an example, consider the set of equations <em>x = x + 1</em>,
 * <em>y = z + 200</em> and <em>z = y + 100</em>.  If this set of equations
 * were interpreted as a set of assignment statements, it would be invalid
 * because the rule for <em>x</em> refers to <em>x</em> (exhibiting one type
 * of loop), and the rule for <em>y</em> refers to <em>z</em> while the rule
 * for <em>z</em> refers back to <em>y</em> (exhibiting another type of loop).
 * Conversely, the following set of equations would constitute a valid set of
 * assignment statements: <em>x = 10</em>, <em>y = z + 200</em>, and <em>z = x
 * + 100</em>.
 <p>
 * <h3>A model must not be overdetermined</h3>
 <p>
 * An SBML model must not be overdetermined; that is, a model must not
 * define more equations than there are unknowns in a model.  A valid SBML model
 * that does not contain {@link AlgebraicRule} structures cannot be overdetermined.
 <p>
 * LibSBML implements the static analysis procedure described in
 * Appendix&nbsp;B of the SBML Level&nbsp;3
 * specification for assessing whether a model is overdetermined.
 <p>
 * (In summary, assessing whether a given continuous, deterministic,
 * mathematical model is overdetermined does not require dynamic analysis; it
 * can be done by analyzing the system of equations created from the model.
 * One approach is to construct a bipartite graph in which one set of vertices
 * represents the variables and the other the set of vertices represents the
 * equations.  Place edges between vertices such that variables in the system
 * are linked to the equations that determine them.  For algebraic equations,
 * there will be edges between the equation and each variable occurring in the
 * equation.  For ordinary differential equations (such as those defined by
 * rate rules or implied by the reaction rate definitions), there will be a
 * single edge between the equation and the variable determined by that
 * differential equation.  A mathematical model is overdetermined if the
 * maximal matchings of the bipartite graph contain disconnected vertexes
 * representing equations.  If one maximal matching has this property, then
 * all the maximal matchings will have this property; i.e., it is only
 * necessary to find one maximal matching.)
 <p>
 * <h2>Rule types for SBML Level 1</h2>
 <p>
 * SBML Level 1 uses a different scheme than SBML Level 2 and Level 3 for
 * distinguishing rules; specifically, it uses an attribute whose value is
 * drawn from an enumeration of 3 values.  LibSBML supports this using methods
 * that work with the enumeration values  listed below.
 <p>
 * <ul>
 * <li> {@link libsbmlConstants#RULE_TYPE_RATE RULE_TYPE_RATE}: Indicates
 * the rule is a 'rate' rule.
 * <li> {@link libsbmlConstants#RULE_TYPE_SCALAR RULE_TYPE_SCALAR}:
 * Indicates the rule is a 'scalar' rule.
 * <li> {@link libsbmlConstants#RULE_TYPE_INVALID RULE_TYPE_INVALID}:
 * Indicates the rule type is unknown or not yet set.
 *
 * </ul>
 */

public class RateRule extends Rule {
   private long swigCPtr;

   protected RateRule(long cPtr, boolean cMemoryOwn)
   {
     super(libsbmlJNI.RateRule_SWIGUpcast(cPtr), cMemoryOwn);
     swigCPtr = cPtr;
   }

   protected static long getCPtr(RateRule obj)
   {
     return (obj == null) ? 0 : obj.swigCPtr;
   }

   protected static long getCPtrAndDisown (RateRule obj)
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
        libsbmlJNI.delete_RateRule(swigCPtr);
      }
      swigCPtr = 0;
    }
    super.delete();
  }


/**
   * Creates a new {@link RateRule} using the given SBML <code>level</code> and <code>version</code>
   * values.
   <p>
   * @param level a long integer, the SBML Level to assign to this {@link RateRule}.
   <p>
   * @param version a long integer, the SBML Version to assign to this
   * {@link RateRule}.
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
 RateRule(long level, long version) throws org.sbml.libsbml.SBMLConstructorException {
    this(libsbmlJNI.new_RateRule__SWIG_0(level, version), true);
  }


/**
   * Creates a new {@link RateRule} using the given {@link SBMLNamespaces} object
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
 RateRule(SBMLNamespaces sbmlns) throws org.sbml.libsbml.SBMLConstructorException {
    this(libsbmlJNI.new_RateRule__SWIG_1(SBMLNamespaces.getCPtr(sbmlns), sbmlns), true);
  }


/**
   * Creates and returns a deep copy of this {@link RateRule} object.
   <p>
   * @return the (deep) copy of this {@link RateRule} object.
   */ public
 RateRule cloneObject() {
    long cPtr = libsbmlJNI.RateRule_cloneObject(swigCPtr, this);
    return (cPtr == 0) ? null : new RateRule(cPtr, true);
  }


/**
   * Predicate returning <code>true</code> if
   * all the required attributes for this {@link RateRule} object
   * have been set.
   <p>
   * In SBML Levels&nbsp;2&ndash;3, the only required attribute for a
   * {@link RateRule} object is 'variable'.  For Level&nbsp;1, where the equivalent
   * attribute is known by different names ('compartment', 'species', or
   * 'name', depending on the type of object), there is an additional
   * required attribute called 'formula'.
   <p>
   * @return <code>true</code> if the required attributes have been set, <code>false</code>
   * otherwise.
   */ public
 boolean hasRequiredAttributes() {
    return libsbmlJNI.RateRule_hasRequiredAttributes(swigCPtr, this);
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
    libsbmlJNI.RateRule_renameSIdRefs(swigCPtr, this, oldid, newid);
  }

}