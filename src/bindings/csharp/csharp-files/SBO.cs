using System;
using System.Runtime.InteropServices;

/* ----------------------------------------------------------------------------
 * This file was automatically generated by SWIG (http://www.swig.org).
 * Version 2.0.6
 *
 * Do not make changes to this file unless you know what you are doing--modify
 * the SWIG interface file instead.
 * ----------------------------------------------------------------------------- */

namespace libsbmlcs {

 using System;
 using System.Runtime.InteropServices;

/**
 * @sbmlpackage{core}
 *
@htmlinclude pkg-marker-core.html Facilities for using the Systems Biology Ontology.
 *
 * @htmlinclude not-sbml-warning.html
 *
 * The values of 'id' attributes on SBML components allow the components to
 * be cross-referenced within a model. The values of 'name' attributes on
 * SBML components provide the opportunity to assign them meaningful labels
 * suitable for display to humans.  The specific identifiers and labels
 * used in a model necessarily must be unrestricted by SBML, so that
 * software and users are free to pick whatever they need.  However, this
 * freedom makes it more difficult for software tools to determine, without
 * additional human intervention, the semantics of models more precisely
 * than the semantics provided by the SBML object classes defined in other
 * sections of this document.  For example, there is nothing inherent in a
 * parameter with identifier <code>k</code> that would indicate to a
 * software tool it is a first-order rate constant (if that's what
 * <code>k</code> happened to be in some given model).  However, one may
 * need to convert a model between different representations (e.g.,
 * Henri-Michaelis-Menten versus elementary steps), or to use it with
 * different modeling approaches (discrete or continuous).  One may also
 * need to relate the model components with other description formats such
 * as SBGN (<a target='_blank'
 * href='http://www.sbgn.org/'>http://www.sbgn.org/</a>) using deeper
 * semantics.  Although an advanced software tool <em>might</em> be able to
 * deduce the semantics of some model components through detailed analysis
 * of the kinetic rate expressions and other parts of the model, this
 * quickly becomes infeasible for any but the simplest of models.
 *
 * An approach to solving this problem is to associate model components
 * with terms from carefully curated controlled vocabularies (CVs).  This
 * is the purpose of the optional 'sboTerm' attribute provided on the SBML
 * class SBase.  The 'sboTerm' attribute always refers to terms belonging
 * to the Systems Biology Ontology (SBO).
 *
 * @section use Use of SBO
 *
 * Labeling model components with terms from shared controlled vocabularies
 * allows a software tool to identify each component using identifiers that
 * are not tool-specific.  An example of where this is useful is the desire
 * by many software developers to provide users with meaningful names for
 * reaction rate equations.  Software tools with editing interfaces
 * frequently provide these names in menus or lists of choices for users.
 * However, without a standardized set of names or identifiers shared
 * between developers, a given software package cannot reliably interpret
 * the names or identifiers of reactions used in models written by other
 * tools.
 *
 * The first solution that might come to mind is to stipulate that certain
 * common reactions always have the same name (e.g., 'Michaelis-Menten'), but
 * this is simply impossible to do: not only do humans often disagree on
 * the names themselves, but it would not allow for correction of errors or
 * updates to the list of predefined names except by issuing new releases
 * of the SBML specification---to say nothing of many other limitations
 * with this approach.  Moreover, the parameters and variables that appear
 * in rate expressions also need to be identified in a way that software
 * tools can interpret mechanically, implying that the names of these
 * entities would also need to be regulated.
 *
 * The Systems Biology Ontology (SBO) provides terms for identifying most
 * elements of SBML. The relationship implied by an 'sboTerm' on an SBML
 * model component is <em>is-a</em> between the characteristic of the
 * component meant to be described by %SBO on this element and the %SBO
 * term identified by the value of the 'sboTerm'. By adding %SBO term
 * references on the components of a model, a software tool can provide
 * additional details using independent, shared vocabularies that can
 * enable <em>other</em> software tools to recognize precisely what the
 * component is meant to be.  Those tools can then act on that information.
 * For example, if the %SBO identifier @c 'SBO:0000049' is assigned
 * to the concept of 'first-order irreversible mass-action kinetics,
 * continuous framework', and a given KineticLaw object in a model has an
 * 'sboTerm' attribute with this value, then regardless of the identifier
 * and name given to the reaction itself, a software tool could use this to
 * inform users that the reaction is a first-order irreversible mass-action
 * reaction.  This kind of reverse engineering of the meaning of reactions
 * in a model would be difficult to do otherwise, especially for more
 * complex reaction types.
 *
 * The presence of %SBO labels on Compartment, Species, and Reaction
 * objects in SBML can help map those entities to equivalent concepts in
 * other standards, such as (but not limited to) BioPAX (<a target='_blank'
 * href='http://www.biopax.org/'>http://www.biopax.org/</a>), PSI-MI (<a
 * target='_blank'
 * href='http://www.psidev.info/index.php?q=node/60'>http://www.psidev.info</a>),
 * or the Systems Biology Graphical Notation (SBGN, <a target='_blank'
 * href='http://www.sbgn.org/'>http://www.sbgn.org/</a>).  Such mappings
 * can be used in conversion procedures, or to build interfaces, with %SBO
 * becoming a kind of 'glue' between standards of representation.
 *
 * The presence of the label on a kinetic expression can also allow
 * software tools to make more intelligent decisions about reaction rate
 * expressions.  For example, an application could recognize certain types
 * of reaction formulas as being ones it knows how to solve with optimized
 * procedures.  The application could then use internal, optimized code
 * implementing the rate formula indexed by identifiers such as
 * @c 'SBO:0000049' appearing in SBML models.
 *
 * Finally, %SBO labels may be very valuable when it comes to model
 * integration, by helping identify interfaces, convert mathematical
 * expressions and parameters etc.
 *
 * Although the use of %SBO can be beneficial, it is critical to keep in
 * mind that the presence of an 'sboTerm' value on an object <em>must not
 * change the fundamental mathematical meaning</em> of the model.  An SBML
 * model must be defined such that it stands on its own and does not depend
 * on additional information added by %SBO terms for a correct mathematical
 * interpretation.  %SBO term definitions will not imply any alternative
 * mathematical semantics for any SBML object labeled with that term.  Two
 * important reasons motivate this principle.  First, it would be too
 * limiting to require all software tools to be able to understand the %SBO
 * vocabularies in addition to understanding SBML.  Supporting %SBO is not
 * only additional work for the software developer; for some kinds of
 * applications, it may not make sense.  If %SBO terms on a model are
 * optional, it follows that the SBML model <em>must</em> remain
 * unambiguous and fully interpretable without them, because an application
 * reading the model may ignore the terms.  Second, we believe allowing the
 * use of 'sboTerm' to alter the mathematical meaning of a model would
 * allow too much leeway to shoehorn inconsistent concepts into SBML
 * objects, ultimately reducing the interoperability of the models.
 *
 * @section relationship Relationships between SBO and SBML
 *
 * The goal of %SBO labeling for SBML is to clarify to the fullest extent
 * possible the nature of each element in a model.  The approach taken in
 * %SBO begins with a hierarchically-structured set of controlled
 * vocabularies with six main divisions: (1) entity, (2) participant role,
 * (3) quantitative parameter, (4) modeling framework, (5) mathematical
 * expression, and (6) interaction.  The web site for %SBO (<a
 * target='_blank'
 * href='http://biomodels.net/sbo'>http://biomodels.net</a>) should be
 * consulted for the current version of the ontology.
 *
 * The Systems Biology Ontology (SBO) is not part of SBML; it is being
 * developed separately, to allow the modeling community to evolve the
 * ontology independently of SBML.  However, the terms in the ontology are
 * being designed keeping SBML components in mind, and are classified into
 * subsets that can be directly related with SBML components such as
 * reaction rate expressions, parameters, and others.  The use of 'sboTerm'
 * attributes is optional, and the presence of 'sboTerm' on an element does
 * not change the way the model is <em>interpreted</em>.  Annotating SBML
 * elements with %SBO terms adds additional semantic information that may
 * be used to <em>convert</em> the model into another model, or another
 * format.  Although %SBO support provides an important source of
 * information to understand the meaning of a model, software does not need
 * to support 'sboTerm' to be considered SBML-compliant.
 *
 */

public class SBO : IDisposable {
	private HandleRef swigCPtr;
	protected bool swigCMemOwn;

	internal SBO(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr    = new HandleRef(this, cPtr);
	}

	internal static HandleRef getCPtr(SBO obj)
	{
		return (obj == null) ? new HandleRef(null, IntPtr.Zero) : obj.swigCPtr;
	}

	internal static HandleRef getCPtrAndDisown (SBO obj)
	{
		HandleRef ptr = new HandleRef(null, IntPtr.Zero);

		if (obj != null)
		{
			ptr             = obj.swigCPtr;
			obj.swigCMemOwn = false;
		}

		return ptr;
	}

  ~SBO() {
    Dispose();
  }

  public virtual void Dispose() {
    lock(this) {
      if (swigCPtr.Handle != IntPtr.Zero) {
        if (swigCMemOwn) {
          swigCMemOwn = false;
          libsbmlPINVOKE.delete_SBO(swigCPtr);
        }
        swigCPtr = new HandleRef(null, IntPtr.Zero);
      }
      GC.SuppressFinalize(this);
    }
  }


/**
   * Returns @c true if the given term identifier comes from the stated branch of %SBO.
   *
   * @note The @em 'quantitative parameter' SBO term is now known as 'systems description parameter'.
   *
   * @return @c true if @p term is-a %SBO <em>'quantiative parameter'</em>, @c false
   * otherwise.
   *
   *
 * @if python @note Because this is a static method on a class, the Python
 * language interface for libSBML will contain two variants.  One will be the
 * expected, normal static method on the class (i.e., a regular
 * <em>methodName</em>), and the other will be a standalone top-level
 * function with the name <em>ClassName_methodName()</em>. This is merely an
 * artifact of how the language interfaces are created in libSBML.  The
 * methods are functionally identical. @endif
 *
 *
   */ public
 static bool isQuantitativeParameter(long term) {
    bool ret = libsbmlPINVOKE.SBO_isQuantitativeParameter(term);
    return ret;
  }


/**
   * Returns @c true if the given term identifier comes from the stated branch of %SBO.
   *
   * @return @c true if @p term is-a %SBO <em>'participant role'</em>, @c false otherwise.
   *
   *
 * @if python @note Because this is a static method on a class, the Python
 * language interface for libSBML will contain two variants.  One will be the
 * expected, normal static method on the class (i.e., a regular
 * <em>methodName</em>), and the other will be a standalone top-level
 * function with the name <em>ClassName_methodName()</em>. This is merely an
 * artifact of how the language interfaces are created in libSBML.  The
 * methods are functionally identical. @endif
 *
 *
   */ public
 static bool isParticipantRole(long term) {
    bool ret = libsbmlPINVOKE.SBO_isParticipantRole(term);
    return ret;
  }


/**
   * Returns @c true if the given term identifier comes from the stated branch of %SBO.
   *
   * @return @c true if @p term is-a %SBO <em>'modeling framework'</em>, @c false otherwise.
   *
   *
 * @if python @note Because this is a static method on a class, the Python
 * language interface for libSBML will contain two variants.  One will be the
 * expected, normal static method on the class (i.e., a regular
 * <em>methodName</em>), and the other will be a standalone top-level
 * function with the name <em>ClassName_methodName()</em>. This is merely an
 * artifact of how the language interfaces are created in libSBML.  The
 * methods are functionally identical. @endif
 *
 *
   */ public
 static bool isModellingFramework(long term) {
    bool ret = libsbmlPINVOKE.SBO_isModellingFramework(term);
    return ret;
  }


/**
   * Returns @c true if the given term identifier comes from the stated branch of %SBO.
   *
   * @return @c true if @p term is-a %SBO <em>'mathematical expression'</em>, @c false otherwise.
   *
   *
 * @if python @note Because this is a static method on a class, the Python
 * language interface for libSBML will contain two variants.  One will be the
 * expected, normal static method on the class (i.e., a regular
 * <em>methodName</em>), and the other will be a standalone top-level
 * function with the name <em>ClassName_methodName()</em>. This is merely an
 * artifact of how the language interfaces are created in libSBML.  The
 * methods are functionally identical. @endif
 *
 *
   */ public
 static bool isMathematicalExpression(long term) {
    bool ret = libsbmlPINVOKE.SBO_isMathematicalExpression(term);
    return ret;
  }


/**
   * Returns @c true if the given term identifier comes from the stated branch of %SBO.
   *
   * @return @c true if @p term is-a %SBO <em>'kinetic constant'</em>, @c false otherwise.
   *
   *
 * @if python @note Because this is a static method on a class, the Python
 * language interface for libSBML will contain two variants.  One will be the
 * expected, normal static method on the class (i.e., a regular
 * <em>methodName</em>), and the other will be a standalone top-level
 * function with the name <em>ClassName_methodName()</em>. This is merely an
 * artifact of how the language interfaces are created in libSBML.  The
 * methods are functionally identical. @endif
 *
 *
   */ public
 static bool isKineticConstant(long term) {
    bool ret = libsbmlPINVOKE.SBO_isKineticConstant(term);
    return ret;
  }


/**
   * Returns @c true if the given term identifier comes from the stated branch of %SBO.
   *
   * @return @c true if @p term is-a %SBO <em>'reactant'</em>, @c false otherwise.
   *
   *
 * @if python @note Because this is a static method on a class, the Python
 * language interface for libSBML will contain two variants.  One will be the
 * expected, normal static method on the class (i.e., a regular
 * <em>methodName</em>), and the other will be a standalone top-level
 * function with the name <em>ClassName_methodName()</em>. This is merely an
 * artifact of how the language interfaces are created in libSBML.  The
 * methods are functionally identical. @endif
 *
 *
   */ public
 static bool isReactant(long term) {
    bool ret = libsbmlPINVOKE.SBO_isReactant(term);
    return ret;
  }


/**
   * Returns @c true if the given term identifier comes from the stated branch of %SBO.
   *
   * @return @c true if @p term is-a %SBO <em>'product'</em>, @c false otherwise.
   *
   *
 * @if python @note Because this is a static method on a class, the Python
 * language interface for libSBML will contain two variants.  One will be the
 * expected, normal static method on the class (i.e., a regular
 * <em>methodName</em>), and the other will be a standalone top-level
 * function with the name <em>ClassName_methodName()</em>. This is merely an
 * artifact of how the language interfaces are created in libSBML.  The
 * methods are functionally identical. @endif
 *
 *
   */ public
 static bool isProduct(long term) {
    bool ret = libsbmlPINVOKE.SBO_isProduct(term);
    return ret;
  }


/**
   * Returns @c true if the given term identifier comes from the stated branch of %SBO.
   *
   * @return @c true if @p term is-a %SBO <em>'modifier'</em>, @c false otherwise.
   *
   *
 * @if python @note Because this is a static method on a class, the Python
 * language interface for libSBML will contain two variants.  One will be the
 * expected, normal static method on the class (i.e., a regular
 * <em>methodName</em>), and the other will be a standalone top-level
 * function with the name <em>ClassName_methodName()</em>. This is merely an
 * artifact of how the language interfaces are created in libSBML.  The
 * methods are functionally identical. @endif
 *
 *
   */ public
 static bool isModifier(long term) {
    bool ret = libsbmlPINVOKE.SBO_isModifier(term);
    return ret;
  }


/**
   * Returns @c true if the given term identifier comes from the stated branch of %SBO.
   *
   * @return @c true if @p term is-a %SBO <em>'rate law'</em>, @c false otherwise.
   *
   *
 * @if python @note Because this is a static method on a class, the Python
 * language interface for libSBML will contain two variants.  One will be the
 * expected, normal static method on the class (i.e., a regular
 * <em>methodName</em>), and the other will be a standalone top-level
 * function with the name <em>ClassName_methodName()</em>. This is merely an
 * artifact of how the language interfaces are created in libSBML.  The
 * methods are functionally identical. @endif
 *
 *
   */ public
 static bool isRateLaw(long term) {
    bool ret = libsbmlPINVOKE.SBO_isRateLaw(term);
    return ret;
  }


/**
   * Returns @c true if the given term identifier comes from the stated branch of %SBO.
   *
   * @return @c true if @p term is-a %SBO <em>'event'</em>, @c false otherwise.
   *
   *
 * @if python @note Because this is a static method on a class, the Python
 * language interface for libSBML will contain two variants.  One will be the
 * expected, normal static method on the class (i.e., a regular
 * <em>methodName</em>), and the other will be a standalone top-level
 * function with the name <em>ClassName_methodName()</em>. This is merely an
 * artifact of how the language interfaces are created in libSBML.  The
 * methods are functionally identical. @endif
 *
 *
   */ public
 static bool isEvent(long term) {
    bool ret = libsbmlPINVOKE.SBO_isEvent(term);
    return ret;
  }


/**
    * Returns @c true if the given term identifier comes from the stated branch of %SBO.
    *
    * @return @c true if @p term is-a %SBO <em>'physical participant</em>, @c false otherwise.
   *
   *
 * @if python @note Because this is a static method on a class, the Python
 * language interface for libSBML will contain two variants.  One will be the
 * expected, normal static method on the class (i.e., a regular
 * <em>methodName</em>), and the other will be a standalone top-level
 * function with the name <em>ClassName_methodName()</em>. This is merely an
 * artifact of how the language interfaces are created in libSBML.  The
 * methods are functionally identical. @endif
 *
 *
    */ public
 static bool isPhysicalParticipant(long term) {
    bool ret = libsbmlPINVOKE.SBO_isPhysicalParticipant(term);
    return ret;
  }


/**
   * Returns @c true if the given term identifier comes from the stated branch of %SBO.
   *
   * @return @c true if @p term is-a %SBO <em>'participant'</em>, @c false otherwise.
   *
   *
 * @if python @note Because this is a static method on a class, the Python
 * language interface for libSBML will contain two variants.  One will be the
 * expected, normal static method on the class (i.e., a regular
 * <em>methodName</em>), and the other will be a standalone top-level
 * function with the name <em>ClassName_methodName()</em>. This is merely an
 * artifact of how the language interfaces are created in libSBML.  The
 * methods are functionally identical. @endif
 *
 *
   */ public
 static bool isParticipant(long term) {
    bool ret = libsbmlPINVOKE.SBO_isParticipant(term);
    return ret;
  }


/**
   * Returns @c true if the given term identifier comes from the stated branch of %SBO.
   *
   * @note The @em 'interaction' SBO term is now known as 'occurring entity representation'.
   *
   * @return @c true if @p term is-a %SBO <em>'interaction'</em>, @c false otherwise.
   *
   *
 * @if python @note Because this is a static method on a class, the Python
 * language interface for libSBML will contain two variants.  One will be the
 * expected, normal static method on the class (i.e., a regular
 * <em>methodName</em>), and the other will be a standalone top-level
 * function with the name <em>ClassName_methodName()</em>. This is merely an
 * artifact of how the language interfaces are created in libSBML.  The
 * methods are functionally identical. @endif
 *
 *
   */ public
 static bool isInteraction(long term) {
    bool ret = libsbmlPINVOKE.SBO_isInteraction(term);
    return ret;
  }


/**
   * Returns @c true if the given term identifier comes from the stated branch of %SBO.
   *
   * @note The @em 'entity' SBO term is now known as 'physical entity representation'.
   *
   * @return @c true if @p term is-a %SBO <em>'entity'</em>, @c false otherwise.
   *
   *
 * @if python @note Because this is a static method on a class, the Python
 * language interface for libSBML will contain two variants.  One will be the
 * expected, normal static method on the class (i.e., a regular
 * <em>methodName</em>), and the other will be a standalone top-level
 * function with the name <em>ClassName_methodName()</em>. This is merely an
 * artifact of how the language interfaces are created in libSBML.  The
 * methods are functionally identical. @endif
 *
 *
   */ public
 static bool isEntity(long term) {
    bool ret = libsbmlPINVOKE.SBO_isEntity(term);
    return ret;
  }


/**
   * Returns @c true if the given term identifier comes from the stated branch of %SBO.
   *
   * @return @c true if @p term is-a %SBO <em>'functional entity'</em>, @c false otherwise.
   *
   *
 * @if python @note Because this is a static method on a class, the Python
 * language interface for libSBML will contain two variants.  One will be the
 * expected, normal static method on the class (i.e., a regular
 * <em>methodName</em>), and the other will be a standalone top-level
 * function with the name <em>ClassName_methodName()</em>. This is merely an
 * artifact of how the language interfaces are created in libSBML.  The
 * methods are functionally identical. @endif
 *
 *
   */ public
 static bool isFunctionalEntity(long term) {
    bool ret = libsbmlPINVOKE.SBO_isFunctionalEntity(term);
    return ret;
  }


/**
   * Returns @c true if the given term identifier comes from the stated branch of %SBO.
   *
   * @return @c true if @p term is-a %SBO <em>'material entity'</em>, @c false otherwise.
   *
   *
 * @if python @note Because this is a static method on a class, the Python
 * language interface for libSBML will contain two variants.  One will be the
 * expected, normal static method on the class (i.e., a regular
 * <em>methodName</em>), and the other will be a standalone top-level
 * function with the name <em>ClassName_methodName()</em>. This is merely an
 * artifact of how the language interfaces are created in libSBML.  The
 * methods are functionally identical. @endif
 *
 *
   */ public
 static bool isMaterialEntity(long term) {
    bool ret = libsbmlPINVOKE.SBO_isMaterialEntity(term);
    return ret;
  }


/**
   * Returns @c true if the given term identifier comes from the stated branch of %SBO.
   *
   * @return @c true if @p term is-a %SBO <em>'conservation law'</em>, @c false otherwise.
   *
   *
 * @if python @note Because this is a static method on a class, the Python
 * language interface for libSBML will contain two variants.  One will be the
 * expected, normal static method on the class (i.e., a regular
 * <em>methodName</em>), and the other will be a standalone top-level
 * function with the name <em>ClassName_methodName()</em>. This is merely an
 * artifact of how the language interfaces are created in libSBML.  The
 * methods are functionally identical. @endif
 *
 *
   */ public
 static bool isConservationLaw(long term) {
    bool ret = libsbmlPINVOKE.SBO_isConservationLaw(term);
    return ret;
  }


/**
   * Returns @c true if the given term identifier comes from the stated branch of %SBO.
   *
   * @return @c true if @p term is-a %SBO <em>'steady state expression'</em>, @c false otherwise.
   *
   *
 * @if python @note Because this is a static method on a class, the Python
 * language interface for libSBML will contain two variants.  One will be the
 * expected, normal static method on the class (i.e., a regular
 * <em>methodName</em>), and the other will be a standalone top-level
 * function with the name <em>ClassName_methodName()</em>. This is merely an
 * artifact of how the language interfaces are created in libSBML.  The
 * methods are functionally identical. @endif
 *
 *
   */ public
 static bool isSteadyStateExpression(long term) {
    bool ret = libsbmlPINVOKE.SBO_isSteadyStateExpression(term);
    return ret;
  }


/**
   * Returns @c true if the given term identifier comes from the stated branch of %SBO.
   *
   * @return @c true if @p term is-a %SBO <em>'functional compartment'</em>, @c false otherwise.
   *
   *
 * @if python @note Because this is a static method on a class, the Python
 * language interface for libSBML will contain two variants.  One will be the
 * expected, normal static method on the class (i.e., a regular
 * <em>methodName</em>), and the other will be a standalone top-level
 * function with the name <em>ClassName_methodName()</em>. This is merely an
 * artifact of how the language interfaces are created in libSBML.  The
 * methods are functionally identical. @endif
 *
 *
   */ public
 static bool isFunctionalCompartment(long term) {
    bool ret = libsbmlPINVOKE.SBO_isFunctionalCompartment(term);
    return ret;
  }


/**
   * Returns @c true if the given term identifier comes from the stated branch of %SBO.
   *
   * @return @c true if @p term is-a %SBO <em>'continuous framework'</em>, @c false otherwise.
   *
   *
 * @if python @note Because this is a static method on a class, the Python
 * language interface for libSBML will contain two variants.  One will be the
 * expected, normal static method on the class (i.e., a regular
 * <em>methodName</em>), and the other will be a standalone top-level
 * function with the name <em>ClassName_methodName()</em>. This is merely an
 * artifact of how the language interfaces are created in libSBML.  The
 * methods are functionally identical. @endif
 *
 *
   */ public
 static bool isContinuousFramework(long term) {
    bool ret = libsbmlPINVOKE.SBO_isContinuousFramework(term);
    return ret;
  }


/**
   * Returns @c true if the given term identifier comes from the stated branch of %SBO.
   *
   * @return @c true if @p term is-a %SBO <em>'discrete framework'</em>, @c false otherwise.
   *
   *
 * @if python @note Because this is a static method on a class, the Python
 * language interface for libSBML will contain two variants.  One will be the
 * expected, normal static method on the class (i.e., a regular
 * <em>methodName</em>), and the other will be a standalone top-level
 * function with the name <em>ClassName_methodName()</em>. This is merely an
 * artifact of how the language interfaces are created in libSBML.  The
 * methods are functionally identical. @endif
 *
 *
   */ public
 static bool isDiscreteFramework(long term) {
    bool ret = libsbmlPINVOKE.SBO_isDiscreteFramework(term);
    return ret;
  }


/**
   * Returns @c true if the given term identifier comes from the stated branch of %SBO.
   *
   * @return @c true if @p term is-a %SBO <em>'logical framework'</em>, @c false otherwise.
   *
   *
 * @if python @note Because this is a static method on a class, the Python
 * language interface for libSBML will contain two variants.  One will be the
 * expected, normal static method on the class (i.e., a regular
 * <em>methodName</em>), and the other will be a standalone top-level
 * function with the name <em>ClassName_methodName()</em>. This is merely an
 * artifact of how the language interfaces are created in libSBML.  The
 * methods are functionally identical. @endif
 *
 *
   */ public
 static bool isLogicalFramework(long term) {
    bool ret = libsbmlPINVOKE.SBO_isLogicalFramework(term);
    return ret;
  }


/**
   * Returns @c true if the given term identifier comes from the stated branch of %SBO.
   *
   * @return @c true if @p term is-a %SBO <em>'metadata representation'</em>, @c false otherwise.
   *
   *
 * @if python @note Because this is a static method on a class, the Python
 * language interface for libSBML will contain two variants.  One will be the
 * expected, normal static method on the class (i.e., a regular
 * <em>methodName</em>), and the other will be a standalone top-level
 * function with the name <em>ClassName_methodName()</em>. This is merely an
 * artifact of how the language interfaces are created in libSBML.  The
 * methods are functionally identical. @endif
 *
 *
   */ public
 static bool isMetadataRepresentation(long term) {
    bool ret = libsbmlPINVOKE.SBO_isMetadataRepresentation(term);
    return ret;
  }


/**
   * Returns @c true if the given term identifier comes from the stated branch of %SBO.
   *
   * @return @c true if @p term is-a %SBO <em>'occurring entity representation'</em>, @c false otherwise.
   *
   *
 * @if python @note Because this is a static method on a class, the Python
 * language interface for libSBML will contain two variants.  One will be the
 * expected, normal static method on the class (i.e., a regular
 * <em>methodName</em>), and the other will be a standalone top-level
 * function with the name <em>ClassName_methodName()</em>. This is merely an
 * artifact of how the language interfaces are created in libSBML.  The
 * methods are functionally identical. @endif
 *
 *
   */ public
 static bool isOccurringEntityRepresentation(long term) {
    bool ret = libsbmlPINVOKE.SBO_isOccurringEntityRepresentation(term);
    return ret;
  }


/**
   * Returns @c true if the given term identifier comes from the stated branch of %SBO.
   *
   * @return @c true if @p term is-a %SBO <em>'physical entity representation'</em>, @c false otherwise.
   *
   *
 * @if python @note Because this is a static method on a class, the Python
 * language interface for libSBML will contain two variants.  One will be the
 * expected, normal static method on the class (i.e., a regular
 * <em>methodName</em>), and the other will be a standalone top-level
 * function with the name <em>ClassName_methodName()</em>. This is merely an
 * artifact of how the language interfaces are created in libSBML.  The
 * methods are functionally identical. @endif
 *
 *
   */ public
 static bool isPhysicalEntityRepresentation(long term) {
    bool ret = libsbmlPINVOKE.SBO_isPhysicalEntityRepresentation(term);
    return ret;
  }


/**
   * Returns @c true if the given term identifier comes from the stated branch of %SBO.
   *
   * @return @c true if @p term is-a %SBO <em>'systems description parameter'</em>, @c false otherwise.
   *
   *
 * @if python @note Because this is a static method on a class, the Python
 * language interface for libSBML will contain two variants.  One will be the
 * expected, normal static method on the class (i.e., a regular
 * <em>methodName</em>), and the other will be a standalone top-level
 * function with the name <em>ClassName_methodName()</em>. This is merely an
 * artifact of how the language interfaces are created in libSBML.  The
 * methods are functionally identical. @endif
 *
 *
   */ public
 static bool isSystemsDescriptionParameter(long term) {
    bool ret = libsbmlPINVOKE.SBO_isSystemsDescriptionParameter(term);
    return ret;
  }


/**
   * Returns @c true if the given term identifier comes from the stated branch of %SBO.
   *
   * @return @c true if @p term is-a %SBO <em>'quantiative systems description parameter'</em>, @c false
   * otherwise.
   *
   *
 * @if python @note Because this is a static method on a class, the Python
 * language interface for libSBML will contain two variants.  One will be the
 * expected, normal static method on the class (i.e., a regular
 * <em>methodName</em>), and the other will be a standalone top-level
 * function with the name <em>ClassName_methodName()</em>. This is merely an
 * artifact of how the language interfaces are created in libSBML.  The
 * methods are functionally identical. @endif
 *
 *
   */ public
 static bool isQuantitativeSystemsDescriptionParameter(long term) {
    bool ret = libsbmlPINVOKE.SBO_isQuantitativeSystemsDescriptionParameter(term);
    return ret;
  }


/**
   * Predicate for checking whether the given term is obsolete.
   *
   * @return @c true if @p term is-a %SBO <em>'obsolete'</em> term, @c false otherwise.
   *
   *
 * @if python @note Because this is a static method on a class, the Python
 * language interface for libSBML will contain two variants.  One will be the
 * expected, normal static method on the class (i.e., a regular
 * <em>methodName</em>), and the other will be a standalone top-level
 * function with the name <em>ClassName_methodName()</em>. This is merely an
 * artifact of how the language interfaces are created in libSBML.  The
 * methods are functionally identical. @endif
 *
 *
   */ public
 static bool isObselete(long term) {
    bool ret = libsbmlPINVOKE.SBO_isObselete(term);
    return ret;
  }


/**
   * Returns the integer as a correctly formatted %SBO identifier string.
   *
   * @return the given integer sboTerm as a zero-padded seven digit string.
   *
   * @note If the sboTerm is not in the correct range
   * (0000000&ndash;9999999), an empty string is returned.
   *
   *
 * @if python @note Because this is a static method on a class, the Python
 * language interface for libSBML will contain two variants.  One will be the
 * expected, normal static method on the class (i.e., a regular
 * <em>methodName</em>), and the other will be a standalone top-level
 * function with the name <em>ClassName_methodName()</em>. This is merely an
 * artifact of how the language interfaces are created in libSBML.  The
 * methods are functionally identical. @endif
 *
 *
   */ public
 static string intToString(int sboTerm) {
    string ret = libsbmlPINVOKE.SBO_intToString(sboTerm);
    return ret;
  }


/**
   * Returns the string as a correctly formatted %SBO integer portion.
   *
   * @return the given string sboTerm as an integer.  If the sboTerm is not
   * in the correct format (a zero-padded, seven digit string), <code>-1</code> is
   * returned.
   *
   *
 * @if python @note Because this is a static method on a class, the Python
 * language interface for libSBML will contain two variants.  One will be the
 * expected, normal static method on the class (i.e., a regular
 * <em>methodName</em>), and the other will be a standalone top-level
 * function with the name <em>ClassName_methodName()</em>. This is merely an
 * artifact of how the language interfaces are created in libSBML.  The
 * methods are functionally identical. @endif
 *
 *
   */ public
 static int stringToInt(string sboTerm) {
    int ret = libsbmlPINVOKE.SBO_stringToInt(sboTerm);
    if (libsbmlPINVOKE.SWIGPendingException.Pending) throw libsbmlPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }


/**
   * Checks the format of the given %SBO identifier string.
   *
   * @return @c true if sboTerm is in the correct format (a zero-padded, seven
   * digit string), @c false otherwise.
   *
   *
 * @if python @note Because this is a static method on a class, the Python
 * language interface for libSBML will contain two variants.  One will be the
 * expected, normal static method on the class (i.e., a regular
 * <em>methodName</em>), and the other will be a standalone top-level
 * function with the name <em>ClassName_methodName()</em>. This is merely an
 * artifact of how the language interfaces are created in libSBML.  The
 * methods are functionally identical. @endif
 *
 *
   */ public
 static bool checkTerm(string sboTerm) {
    bool ret = libsbmlPINVOKE.SBO_checkTerm__SWIG_0(sboTerm);
    if (libsbmlPINVOKE.SWIGPendingException.Pending) throw libsbmlPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }


/**
   * Checks the format of the given %SBO identifier, given in the form of
   * the integer portion alone.
   *
   * @return @c true if sboTerm is in the range (0000000&ndash;9999999), @c false
   * otherwise.
   *
   *
 * @if python @note Because this is a static method on a class, the Python
 * language interface for libSBML will contain two variants.  One will be the
 * expected, normal static method on the class (i.e., a regular
 * <em>methodName</em>), and the other will be a standalone top-level
 * function with the name <em>ClassName_methodName()</em>. This is merely an
 * artifact of how the language interfaces are created in libSBML.  The
 * methods are functionally identical. @endif
 *
 *
   */ public
 static bool checkTerm(int sboTerm) {
    bool ret = libsbmlPINVOKE.SBO_checkTerm__SWIG_1(sboTerm);
    return ret;
  }


/** */ /* libsbml-internal */ public
 static long getParentBranch(long term) { return (long)libsbmlPINVOKE.SBO_getParentBranch(term); }

  public SBO() : this(libsbmlPINVOKE.new_SBO(), true) {
  }

}

}