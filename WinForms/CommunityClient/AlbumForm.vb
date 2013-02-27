Public Class AlbumForm

    Private pGallery As String
    Private pAlbum As webserver.Album

    Public Sub New(ByVal GalleryName As String, ByVal Album As webserver.Album)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        pGallery = GalleryName
        pAlbum = Album

        Me.Text = pAlbum.Name

    End Sub


    Private Sub AlbumForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load



    End Sub

End Class