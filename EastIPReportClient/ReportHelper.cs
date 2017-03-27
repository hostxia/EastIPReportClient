using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using EastIPReportClient.DBUtility;

namespace EastIPReportClient
{
    public class ReportHelper
    {
        private DataTable _dtCaseForeign;

        private DataTable _dtCaseForeignEntity;
        public ReportHelper()
        {
            _dtCaseForeignEntity = DbHelperOra.Query("select * from fcase_ent_rel").Tables[0];
        }
        public List<CaseForeign> GetReport(string sClientNo)
        {
            _dtCaseForeign = DbHelperOra.Query($"select f.* from fcase f,fcase_ent_rel r where f.ourno = r.ourno and r.eid = '{sClientNo}'").Tables[0];
            var listResult = new List<CaseForeign>();
            _dtCaseForeign.Rows.Cast<DataRow>().ToList().ForEach(drCase =>
            {

                if (listResult.Any(r => r.CaseNo == drCase["OURNO"].ToString())) return;
                var drsCaseEntity = _dtCaseForeignEntity.Select($"OURNO = '{drCase["OURNO"].ToString()}'");
                var drCaseClient = drsCaseEntity.FirstOrDefault(dr => dr["ROLE"].ToString() == "CLI" || dr["ROLE"].ToString() == "APPCLI");
                var caseForeign = new CaseForeign();
                var sCaseNo = drCase["OURNO"].ToString();
                //我方卷号
                caseForeign.CaseNo = sCaseNo;
                //@"(?<year>\d{2})(?<type>\S{1, 2})(?<flow>\d{4})(?<country>\S*)-?(?<client>\d{4})-?(?<agent>\S*)"

                var regex = Regex.Match(sCaseNo, @"(?<year>\d{2})(?<type>\D{1,2})(?<flow>\d{4})(?<country>\D*?)-?(?<client>\d{4})-?(?<agent>\D*)");
                if (regex.Success)
                {
                    var sAppNo = drCase["APPNO"].ToString();
                    var sAppDate = drCase["APPDATE"].ToString();

                    var dtLog = DbHelperOra.Query($"select * from fcase_log where ourno = '{sCaseNo}'").Tables[0];
                    var drsPubNo = dtLog.Select("item = '01_pub_num'");
                    var drsPubDate = dtLog.Select("item = '01_pub_date'");
                    var drsAnnoNo = dtLog.Select("item = '01_anno_num'");
                    var drsAnnoDate = dtLog.Select("item = '01_anno_date'");

                    var drsPCTPubNo = dtLog.Select("item = '01_pct_pub_num'");
                    var drsPCTPubDate = dtLog.Select("item = '01_pct_pub_date'");
                    //var drsPCTAppNo = dtLog.Select("item = '01_pct_app_num'");
                    //var drsPCTDate = dtLog.Select("item = '01_pct_app_date'");

                    var sPubNo = drsPubNo.Length > 0 ? drsPubNo[0]["CONTENT"].ToString() : string.Empty;
                    var sPubDate = drsPubDate.Length > 0 ? drsPubDate[0]["CONTENT"].ToString() : string.Empty;
                    var sAnnoNo = drsAnnoNo.Length > 0 ? drsAnnoNo[0]["CONTENT"].ToString() : string.Empty;
                    var sAnnoDate = drsAnnoDate.Length > 0 ? drsAnnoDate[0]["CONTENT"].ToString() : string.Empty;
                    var sPCTPubNo = drsPCTPubNo.Length > 0 ? drsPCTPubNo[0]["CONTENT"].ToString() : string.Empty;
                    var sPCTPubDate = drsPCTPubDate.Length > 0 ? drsPCTPubDate[0]["CONTENT"].ToString() : string.Empty;
                    //申请途径、申请国家、客户国际案号、客户国家案号
                    if (regex.Groups["type"].Value == "WI")
                    {
                        caseForeign.AppWay = "巴黎公约途径";
                        caseForeign.Country = regex.Groups["country"].Value;
                        caseForeign.ClientCaseNo = drCaseClient?["ENT_REF"].ToString();
                        caseForeign.AppNo = sAppNo;
                        caseForeign.AppDate = sAppDate;
                        caseForeign.PubNo = sPubNo;
                        caseForeign.PubDate = sPubDate;
                        caseForeign.AnnoNo = sAnnoNo;
                        caseForeign.AnnoDate = sAnnoDate;
                    }
                    else if (regex.Groups["type"].Value == "P")
                    {
                        if (!string.IsNullOrEmpty(regex.Groups["country"].Value))
                        {
                            caseForeign.AppWay = "PCT途径";
                            caseForeign.Country = regex.Groups["country"].Value;
                            caseForeign.ClientCaseNo = drCaseClient?["ENT_REF"].ToString();
                            caseForeign.AppNo = sAppNo;
                            caseForeign.AppDate = sAppDate;
                            caseForeign.PubNo = sPubNo;
                            caseForeign.PubDate = sPubDate;
                            caseForeign.AnnoNo = sAnnoNo;
                            caseForeign.AnnoDate = sAnnoDate;
                        }
                        else
                        {
                            caseForeign.ClientPCTCaseNo = drCaseClient?["ENT_REF"].ToString();
                            caseForeign.PCTAppNo = sAppNo;
                            caseForeign.PCTAppDate = sAppDate;
                            caseForeign.PCTPubNo = sPCTPubNo;
                            if (string.IsNullOrEmpty(caseForeign.PCTPubNo))
                                caseForeign.PCTPubNo = sPubNo;
                            caseForeign.PCTPubDate = sPCTPubDate;
                            if (string.IsNullOrEmpty(caseForeign.PCTPubDate))
                                caseForeign.PCTPubDate = sPCTPubDate;
                        }
                    }
                }
                //专利类型
                if (drCase["APPTYPE"].ToString().Contains("I;"))
                {
                    caseForeign.PatentType = "发明";
                }
                else if (drCase["APPTYPE"].ToString().Contains("U;"))
                {
                    caseForeign.PatentType = "实用新型";
                }
                else if (drCase["APPTYPE"].ToString().Contains("D;"))
                {
                    caseForeign.PatentType = "外观";
                }
                if (!string.IsNullOrEmpty(regex.Groups["agent"].Value))
                    caseForeign.Agent = regex.Groups["agent"].Value;
                caseForeign.Agency = "北京东方亿思知识产权代理有限责任公司";
                //外所名称、外所卷号
                var drsAgency = _dtCaseForeignEntity.Select($"ourno = '{sCaseNo}' and role = 'AGT'").FirstOrDefault();
                caseForeign.ForeignAgency = drsAgency?["ORIG_NAME"].ToString();
                caseForeign.ForeignAgencyNo = drsAgency?["ENT_REF"].ToString();
                //发明人
                var dtInventor = DbHelperOra.Query($"select * from fcase_inventors where ourno = '{sCaseNo}' order by ent_order asc").Tables[0];
                caseForeign.Inventor = string.Join("、", dtInventor.Rows.Cast<DataRow>().Select(r => r["TRAN_NAME"].ToString()).ToList());
                //申请人
                var drsApplicant = _dtCaseForeignEntity.Select($"ourno = '{sCaseNo}' and (role = 'APP' or role = 'APPCLI')");
                caseForeign.Applicant = string.Join("\r\n", drsApplicant.Select(r => r["TRAN_NAME"].ToString()).ToList());
                caseForeign.Title = drCase["CTITLE"].ToString();
                //优先权
                var dtPriority = DbHelperOra.Query($"select * from fcase_priority where ourno = '{sCaseNo}' order by prior_date asc").Tables[0];
                if (dtPriority.Rows.Count > 0)
                {
                    caseForeign.PriorityNo = dtPriority.Rows[0]["PRIOR_NUM"].ToString();
                    caseForeign.PriorityDate = dtPriority.Rows[0]["PRIOR_DATE"].ToString();
                }
                listResult.Add(caseForeign);
            });

            return SetPCTRelation(listResult);
        }

        private List<CaseForeign> SetPCTRelation(List<CaseForeign> listResult)
        {
            listResult.Where(r => r.AppWay == "PCT途径").ToList().ForEach(r =>
               {
                   var regex = Regex.Match(r.CaseNo, @"(?<year>\d{2})(?<type>\D{1,2})(?<flow>\d{4})(?<country>\D*?)-?(?<client>\d{4})-?(?<agent>\D*)");
                   var sPctCaseNo = regex.Groups["year"].Value + regex.Groups["type"].Value + regex.Groups["flow"].Value + "-" + regex.Groups["client"].Value;
                   var pctCase = listResult.FirstOrDefault(c => c.CaseNo.Contains(sPctCaseNo) && string.IsNullOrWhiteSpace(c.AppWay));
                   if (pctCase == null) return;
                   r.ClientPCTCaseNo = pctCase.ClientPCTCaseNo;
                   r.PCTAppDate = pctCase.PCTAppDate;
                   r.PCTAppNo = pctCase.PCTAppNo;
                   r.PCTPubDate = pctCase.PCTPubDate;
                   r.PCTPubNo = pctCase.PCTPubNo;
               });
            return listResult;
        }
    }
}
