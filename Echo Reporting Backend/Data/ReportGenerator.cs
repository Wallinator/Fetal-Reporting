using System;
using System.Collections.Generic;

namespace FetalReporting.Data {
    public static class ReportGenerator {
        public static string GenerateHTML(StructuredReport report, int fontSize) {

            List<string> l1, l2;
            var html = @"<html>
				<head>
				<link rel=""stylesheet"" href=""https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css"" integrity=""sha384-JcKb8q3iqJ61gNV9KGb8thSsNjpSL0n8PARn9HuZOnIxN0hoP+VmmDGMN5t9UJ0Z"" crossorigin=""anonymous"">
				<script src = ""https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"" integrity = ""sha384-B4gt1jrGC7Jh4AgTPSdUtOBvfO8shuf57BaghqFfPlYxofvL8/KUEfYiJOMMV+rV"" crossorigin = ""anonymous""></script>
				</head>";

            html += string.Format("<body style = \"font-size: {0}px;\">", fontSize);
            html += @"<p></p><img src=""https://i.ibb.co/k5KJw8p/letterheadplain2.jpg"" width=""100%"">
			<p><span style = ""font-size: 24px; font-weight: 700; text-decoration-line: underline;"">Fetal Echocardiogram Report</span><br />";
            /*html += @"<p></p>
			<br/>
			<br/>
			<br/>
			<br/>
			<br/>
			<br/>
			<br/>";*/
            html += string.Format("<table style = \"border-collapse: collapse; font-size: {0}px; width: 100%;\" cellpadding = \"0\"><tbody>", fontSize);
            var pd = report.PatientData;
            string age = Math.Floor(pd.PatientAge.Value).ToString();
            if (pd.PatientAge.Value < 1) {
                age = Math.Floor(pd.PatientAge.Value * 12).ToString() + " mo";
            }

            l1 = pd.PatientID.TableString();
            l2 = pd.StudyDate.TableString();
            html += AddPatientDataRow(l1, l2);
            l1 = pd.PatientName.TableString();
            l2 = pd.EstimatedDueDate.TableString();
            html += AddPatientDataRow(l1, l2);
            l1 = pd.PatientDOB.TableString();
            l2 = pd.GestationalAge.TableString();
            html += AddPatientDataRow(l1, l2);
            l1 = new List<string>() { pd.PatientAge.Name, age };
            l2 = pd.FemurLength.TableString();
            l2[1] = pd.FemurLength.Empty ?  "" : l2[1];
            html += AddPatientDataRow(l1, l2);

            l1 = pd.EchoType.TableString();
            l2 = pd.ReasonForStudy.TableString();
            html += AddPatientDataRow(l1, l2);
            l1 = new List<string>() { "", "" };
            l2 = pd.ReferringPhysician.TableString();
            html += AddPatientDataRow(l1, l2);


            html += @"
			</tbody>
			</table><br/>
			<p><span style = ""font-size: 24px; font-weight: 700; text-decoration-line: underline;"">Findings</span><br />
			</p>";


            html += @"
				</tbody>
			</table>
			<p></p>
			<p></p>";
            html += string.Format(@"<div><span style = ""font-weight: bold;""> Situs - </span>{0}", report.Sections.Situs);
            html += string.Format(@"<div><span style = ""font-weight: bold;""> Systemic Veins - </span>{0}</div> ", report.Sections.SystemicVeins);
            html += string.Format(@"<div><span style = ""font-weight: bold;""> Atria - </span>{0}</div> ", report.Sections.Atria);
            html += string.Format(@"<div><span style = ""font-weight: bold;""> AV Valves - </span>{0}</div></div> ", report.Sections.AVValves);
            html += string.Format(@"<div><span style = ""font-weight: bold;""> Ventricles - </span>{0}", report.Sections.Ventricles);
            html += string.Format(@"<div><span style = ""font-weight: bold;""> Outlets - </span>{0}</div> ", report.Sections.Outlets);
            html += string.Format(@"<div><span style = ""font-weight: bold;""> Great Arteries - </span>{0}</div> ", report.Sections.GreatArteries);
            html += string.Format(@"<div><span style = ""font-weight: bold;""> Pulmonary Veins - </span>{0}</div> ", report.Sections.PulmonaryVeins);
            html += string.Format(@"<div><span style = ""font-weight: bold;""> Other - </span>{0}</div> ", report.Sections.Other);

            html += @"<div></div><br/><div><span style = ""font-weight: bold; text-decoration-line: underline;""> Conclusion </span></div>";
            html += string.Format(@"<div>{0}</div><div><br/>", report.Sections.Conclusion);
            html += string.Format(@"<div><span style = ""font-weight: bold;""> Reporting - </span>{0}</div>", report.Sections.SignOff);
            html += "<br/></div></div><p></p><p></p></body></html>";
            return html;
        }

        private static string AddPatientDataRow(List<string> l1, List<string> l2) {
            string html = "";
            html += string.Format("<tr><td style = \"height: 0px; width: 0px;\">{0}</td>", l1[0]);
            html += "<td style = \"text-align: center; height: 0px; width: 0px;\"> -</td>";
            html += string.Format("<td style = \"text-align: right; height: 0px; width: 0px;\">{0}</td>", l1[1]);
            html += @" <td style = ""height: 0px; width: 0px; text-align: center;""> 
						&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
						&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
						&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
						&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
						<span style = ""white-space:pre""></span></td>";
            html += string.Format("<td style = \"height: 0px; width: 0px;\">{0}</td>", l2[0]);
            html += "<td style = \"text-align: center; height: 0px; width: 0px;\"> -</td>";
            html += string.Format("<td style = \"text-align: right; height: 0px; width: 0px;\">{0}</td></tr>", l2[1]);
            return html;
        }
        private static string AddTableRow(List<string> l1, List<string> l2, List<string> l3) {
            string html = "";
            html += "</tr>";
            html += string.Format("<td style = \"text-align: left;\">{0}</td>", l1[0]);
            html += string.Format("<td style = \"text-align: left;\">{0}</td>", l1[1]);
            html += string.Format("<td style = \"text-align: left;\">{0}</td>", l1[3]);
            html += string.Format("<td style = \"text-align: left;\">{0}</td>", l2[0]);
            html += string.Format("<td style = \"text-align: left;\">{0}</td>", l2[1] + " " + l2[2]);
            html += string.Format("<td style = \"text-align: left;\">{0}</td>", l3[0]);
            html += string.Format("<td style = \"text-align: left;\">{0}</td>", l3[1] + " " + l3[2]);
            html += "</tr>";
            return html;
        }
    }
}
