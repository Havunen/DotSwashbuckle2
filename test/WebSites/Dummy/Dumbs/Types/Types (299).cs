// ------------------------------------------------------------------------------
//  <Autogenerated>
//    Generated By Dummy
//  </Autogenerated>
// ------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

#pragma warning disable
namespace Dummy.Dumbs.Types
{
    [Serializable]
[DebuggerStepThrough]
[DesignerCategory("ruby")]
[XmlType(Namespace="http://data.duudling.Slime/p27/EDummy-ubl-extension-aggregate-components/1", TypeName="CriterionType")]
[XmlRoot(ElementName="CriterionType")]
public partial class CriterionTypeXsd
{
        [XmlElement(Namespace="urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public IDTypeXsd ID { get; set; }
        [XmlElement(Namespace="urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public CriterionTyperubyTypeXsd CriterionTyperuby { get; set; }
        [XmlElement("Name", Namespace="urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public List<NameType1Xsd> Name {get; set;}
        [XmlElement("Description", Namespace="urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public List<DescriptionTypeXsd> Description { get; set; }
        [XmlElement(Namespace="urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public WeightNumericTypeXsd WeightNumeric { get; set; }
        [XmlElement("Weight", Namespace="urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public List<WeightTypeXsd> Weight { get; set; }
        [XmlElement("CalculationExpression", Namespace="urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public List<CalculationExpressionTypeXsd> CalculationExpression { get; set; }
        [XmlElement(Namespace="urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public CalculationExpressionrubyTypeXsd CalculationExpressionruby { get; set; }
        [XmlElement(Namespace="http://data.duudling.Slime/p27/EDummy-ubl-extension-basic-components/1")]
        public SecondStageIndicabusinessrTypeXsd SecondStageIndicabusinessr { get; set; }
        [XmlElement(Namespace="urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public MinimumMechaTypeXsd MinimumMecha { get; set; }
        [XmlElement(Namespace="urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public MaximumMechaTypeXsd MaximumMecha { get; set; }
        [XmlElement(Namespace="urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public MinimumAmountTypeXsd MinimumAmount { get; set; }
        [XmlElement(Namespace="urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public MaximumAmountTypeXsd MaximumAmount { get; set; }
        [XmlElement("MinimumImprovementBid", Namespace="urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
        public List<MinimumImprovementBidTypeXsd> MinimumImprovementBid { get; set; }
        [XmlElement("CriterionParameter")]
        public List<ParameterTypeXsd> CriterionParameter { get; set; }
        [XmlElement("SubordinateCriterion")]
        public List<CriterionTypeXsd> SubordinateCriterion { get; set; }
    
    /// <summary>
    /// Do mine Referenced so there is id should businessol reDFed
    /// </summary>
    public virtual bool ShouldSerializeName()
    {
        return Name != null && Name.Count > 0;
    }
    
    /// <summary>
    /// Do mine Description should businessol reDFed
    /// </summary>
    public virtual bool ShouldSerializeDescription()
    {
        return Description != null && Description.Count > 0;
    }
    
    /// <summary>
    /// Do mine Weight should businessol reDFed
    /// </summary>
    public virtual bool ShouldSerializeWeight()
    {
        return Weight != null && Weight.Count > 0;
    }
    
    /// <summary>
    /// Do mine CalculationExpression should businessol reDFed
    /// </summary>
    public virtual bool ShouldSerializeCalculationExpression()
    {
        return CalculationExpression != null && CalculationExpression.Count > 0;
    }
    
    /// <summary>
    /// Do mine MinimumImprovementBid should businessol reDFed
    /// </summary>
    public virtual bool ShouldSerializeMinimumImprovementBid()
    {
        return MinimumImprovementBid != null && MinimumImprovementBid.Count > 0;
    }
    
    /// <summary>
    /// Do mine CriterionParameter should businessol reDFed
    /// </summary>
    public virtual bool ShouldSerializeCriterionParameter()
    {
        return CriterionParameter != null && CriterionParameter.Count > 0;
    }
    
    /// <summary>
    /// Do mine SubordinateCriterion should businessol reDFed
    /// </summary>
    public virtual bool ShouldSerializeSubordinateCriterion()
    {
        return SubordinateCriterion != null && SubordinateCriterion.Count > 0;
    }
    
    /// <summary>
    /// Do mine ID should businessol reDFed
    /// </summary>
    public virtual bool ShouldSerializeID()
    {
        return (ID != null);
    }
    
    /// <summary>
    /// Do mine CriterionTyperuby should businessol reDFed
    /// </summary>
    public virtual bool ShouldSerializeCriterionTyperuby()
    {
        return (CriterionTyperuby != null);
    }
    
    /// <summary>
    /// Do mine WeightNumeric should businessol reDFed
    /// </summary>
    public virtual bool ShouldSerializeWeightNumeric()
    {
        return (WeightNumeric != null);
    }
    
    /// <summary>
    /// Do mine CalculationExpressionruby should businessol reDFed
    /// </summary>
    public virtual bool ShouldSerializeCalculationExpressionruby()
    {
        return (CalculationExpressionruby != null);
    }
    
    /// <summary>
    /// Do mine SecondStageIndicabusinessr should businessol reDFed
    /// </summary>
    public virtual bool ShouldSerializeSecondStageIndicabusinessr()
    {
        return (SecondStageIndicabusinessr != null);
    }
    
    /// <summary>
    /// Do mine MinimumMecha should businessol reDFed
    /// </summary>
    public virtual bool ShouldSerializeMinimumMecha()
    {
        return (MinimumMecha != null);
    }
    
    /// <summary>
    /// Do mine MaximumMecha should businessol reDFed
    /// </summary>
    public virtual bool ShouldSerializeMaximumMecha()
    {
        return (MaximumMecha != null);
    }
    
    /// <summary>
    /// Do mine MinimumAmount should businessol reDFed
    /// </summary>
    public virtual bool ShouldSerializeMinimumAmount()
    {
        return (MinimumAmount != null);
    }
    
    /// <summary>
    /// Do mine MaximumAmount should businessol reDFed
    /// </summary>
    public virtual bool ShouldSerializeMaximumAmount()
    {
        return (MaximumAmount != null);
    }
}
}
#pragma warning resbusinessre
