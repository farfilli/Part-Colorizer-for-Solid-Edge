Imports SolidEdgeFramework
Imports SolidEdgeGeometry
Imports SolidEdgePart

Public Class Form_PartColorizer
    Private Sub Form_PartColorizer_Load(sender As Object, e As EventArgs) Handles Me.Load

        Dim objApp As SolidEdgeFramework.Application

        Try
            objApp = GetObject(, "SolidEdge.Application")
        Catch ex As Exception
            MsgBox("Solid Edge must be running")
            End
        End Try

        If objApp.Documents.Count = 0 Then
            MsgBox("A part or sheetmetal document must be open")
            End
        End If

        Select Case objApp.ActiveDocumentType
            Case Is = SolidEdgeFramework.DocumentTypeConstants.igPartDocument, SolidEdgeFramework.DocumentTypeConstants.igSyncPartDocument, SolidEdgeFramework.DocumentTypeConstants.igSheetMetalDocument, SolidEdgeFramework.DocumentTypeConstants.igSyncSheetMetalDocument

            Case Else
                MsgBox("A part or sheetmetal document must be open")
                End

        End Select

        Dim objPart As Object
        objPart = objApp.ActiveDocument

        Dim Models As SolidEdgePart.Models = objPart.Models
        If Models.Count = 0 Then
            MsgBox("No design bodies found")
            End
        Else

            Dim totFaces As Integer = 0
            For Each tmpModel As SolidEdgePart.Model In Models

                Dim tmpBody = CType(tmpModel.Body, SolidEdgeGeometry.Body)
                Dim FaceType = SolidEdgeGeometry.FeatureTopologyQueryTypeConstants.igQueryAll
                Dim tmpFaces = CType(tmpBody.Faces(FaceType), SolidEdgeGeometry.Faces)

                totFaces += tmpFaces.Count

            Next

            Report.Text = String.Format("Found {0} bodies, {1} faces", Models.Count.ToString, totFaces.ToString)

            'If totFaces > 500 Then
            '    Report.Text += " (Fast mode recommended)"
            '    CheckBackground.Checked = True
            'End If

        End If

        objApp = Nothing

    End Sub

    Private Sub BT_Colorize_Click(sender As Object, e As EventArgs) Handles BT_Colorize.Click

        Dim objApp As SolidEdgeFramework.Application

        Try
            objApp = GetObject(, "SolidEdge.Application")
        Catch ex As Exception
            MsgBox("Solid Edge must be running")
            End
        End Try

        If objApp.Documents.Count = 0 Then
            MsgBox("A part or sheetmetal document must be open")
            End
        End If

        Select Case objApp.ActiveDocumentType
            Case Is = SolidEdgeFramework.DocumentTypeConstants.igPartDocument, SolidEdgeFramework.DocumentTypeConstants.igSyncPartDocument, SolidEdgeFramework.DocumentTypeConstants.igSheetMetalDocument, SolidEdgeFramework.DocumentTypeConstants.igSyncSheetMetalDocument

            Case Else
                MsgBox("A part or sheetmetal document must be open")
                End

        End Select

        Dim objPart As Object = objApp.ActiveDocument
        Dim tmpName As String = objPart.FullName


        '##### Open in background does't improve performance
        'If CheckBackground.Checked Then
        '    objPart.Close(True)
        '    objPart = SolidEdgeCommunity.Extensions.DocumentsExtensions.OpenInBackground(Of SolidEdgePart.PartDocument)(objApp.Documents, tmpName)
        'End If


        Dim tmpFaceStyles As FaceStyles = objPart.FaceStyles

        Dim Models As SolidEdgePart.Models = objPart.Models
        If Models.Count = 0 Then
            MsgBox("No design bodies found")
            End
        Else
            Report.Text = String.Format("Found {0} bodies", Models.Count)
        End If

        Dim RGBArrayList As New List(Of Double())
        Dim FaceStyleList As New List(Of FaceStyle)
        Dim FacesLists As New List(Of List(Of Face))

        Dim i = 0


        '##### This switches doesn't improve performance
        'objApp.ScreenUpdating = False
        'objApp.Interactive = False
        'objApp.DelayCompute = True


        For Each tmpModel As SolidEdgePart.Model In Models
            i += 1
            Report.Text = String.Format("Processing body: ({0}/{1}) {2}", i.ToString, Models.Count.ToString, tmpModel.BodyName)

            Dim tmpBody = CType(tmpModel.Body, SolidEdgeGeometry.Body)
            Dim FaceType = SolidEdgeGeometry.FeatureTopologyQueryTypeConstants.igQueryAll
            Dim tmpFaces = CType(tmpBody.Faces(FaceType), SolidEdgeGeometry.Faces)

            Report.Text = String.Format("{0} Faces found", tmpFaces.Count.ToString)

            Dim j = 0
            For Each tmpFace As SolidEdgeGeometry.Face In tmpFaces
                j += 1

                If IsNothing(tmpFace.Style) Then

                    Report.Text = String.Format("Processing face {0}/{1} on body {2}/{3}", j.ToString, tmpFaces.Count.ToString, i.ToString, Models.Count.ToString)

                    Dim RVal As Double
                    Dim GVal As Double
                    Dim BVal As Double
                    Dim AVal As Double

                    tmpFace.GetRGBAVals(RVal, GVal, BVal, AVal)

                    Dim RGBArray(3) As Double
                    RGBArray(0) = RVal
                    RGBArray(1) = GVal
                    RGBArray(2) = BVal
                    RGBArray(3) = AVal

                    Dim tmpFaceStyle As FaceStyle
                    'Dim tmpList As List(Of Face)

                    If Not RGBArrayList.Any(Function(dd) dd(0) = RVal And dd(1) = GVal And dd(2) = BVal And dd(3) = AVal) Then

                        RGBArrayList.Add(RGBArray)

                        Try '##### ToDo: Check if a style with the same name already exists
                            tmpFaceStyle = tmpFaceStyles.Add(String.Format("Face style #{0}", CObj(RGBArrayList.Count)), "") 'Tolto stile 'Model Default' perchè non cambia nulla
                            tmpFaceStyle.DiffuseRed = RVal 'CSng(RVal)
                            tmpFaceStyle.DiffuseGreen = GVal 'CSng(GVal)
                            tmpFaceStyle.DiffuseBlue = BVal 'CSng(BVal)
                            tmpFaceStyle.AmbientRed = RVal 'CSng(RVal)
                            tmpFaceStyle.AmbientGreen = GVal 'CSng(GVal)
                            tmpFaceStyle.AmbientBlue = BVal 'CSng(BVal)
                            tmpFaceStyle.WireframeColorRed = RVal 'CSng(RVal)
                            tmpFaceStyle.WireframeColorGreen = GVal 'CSng(GVal)
                            tmpFaceStyle.WireframeColorBlue = BVal 'CSng(BVal)

                            tmpFaceStyle.Opacity = AVal 'CSng(AVal) 'Non è la trasparenza, è 1 anche se colore importato è trasparente
                            'tmpFaceStyle.Shininess = 0.0F
                            'tmpFaceStyle.Reflectivity = 0.0F
                            'tmpFaceStyle.SpecularRed = 0.0F
                            'tmpFaceStyle.SpecularGreen = 0.0F
                            'tmpFaceStyle.SpecularBlue = 0.0F
                            'tmpFaceStyle.EmissionRed = 0.0F
                            'tmpFaceStyle.EmissionGreen = 0.0F
                            'tmpFaceStyle.EmissionBlue = 0.0F
                            FaceStyleList.Add(tmpFaceStyle)

                            'tmpList = New List(Of Face)
                            'FacesLists.Add(tmpList)

                        Catch ex As Exception
                        End Try

                    Else
                        Try '##### ToDo: Check if a style with the same name already exists
                            tmpFaceStyle = FaceStyleList(RGBArrayList.FindIndex(Function(dd) dd(0) = RVal And dd(1) = GVal And dd(2) = BVal And dd(3) = AVal))
                        Catch ex As Exception
                        End Try

                        'tmpList = FacesLists(RGBArrayList.FindIndex(Function(dd) dd(0) = RVal And dd(1) = GVal And dd(2) = BVal And dd(3) = AVal))

                    End If

                    If Not CheckFastMode.Checked Then tmpFace.Style = tmpFaceStyle
                    'tmpList.Add(tmpFace)

                End If

            Next

        Next



        '##### Open in background does't improve performance
        'If CheckBackground.Checked Then

        '    objPart.Close(True)
        '    objApp.Documents.Open(tmpName)

        'End If


        '##### This switches doesn't improve performance
        'objApp.ScreenUpdating = True
        'objApp.Interactive = True
        'objApp.DelayCompute = False


        Report.Text = String.Format("Created {0} FaceStyles", FaceStyleList.Count.ToString)
        objApp = Nothing

    End Sub

End Class
