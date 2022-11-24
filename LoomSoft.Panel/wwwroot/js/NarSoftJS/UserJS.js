function loginBtn() {
    debugger

       // event.preventDefault();
        $("#loginBtn").css({ "background-color": "blue" });

        var userName = $('#username').val();
        var password = $('#password').val();

        if (userName == '' || password == '') {

            swal({
                title: 'Hata!',
                text: "Lütfen Kullanıcı ve adı şifrenizi giriniz!",
                type: 'error',
                padding: '2em'
            });
            return;
        }


        var request = JSON.stringify({
            'UserName': userName,
            'Password': password
        });

        $.ajax({
            async: true,
            url: "/User/LoginControl",
            data: request,
            contentType: "application/json",
            type: "POST",
            success: function (veriler) {               
                console.log(veriler);

                if (veriler.aciklama == 'Lokasyon') {

                    htmltext = '';
                    htmltext += '<select id="company" class="form-control  basic">';
                    htmltext += ' <option value="">Şirket Seçiniz</option>'
                    for (var i = 0; i < veriler.companyList.length; i++) {
                        htmltext += ' <option value="' + veriler.companyList[i].id + '">' + veriler.companyList[i].name + '</option>'
                    }
                    htmltext += ' </select >';
                    $("#company-field").html(htmltext);
                    $("#companyDiv").removeAttr('hidden')
                    $("#companyBtn").hide();
                }
                else {

                    swal({
                        title: 'Hata!',
                        text: veriler.aciklama,
                        type: 'error',
                        padding: '2em'
                    });
                }

            }, error: function (jqXHR, exception) {
                console.log(jqXHR);
                console.log(exception);
                swal({
                    title: 'Hata!',
                    text: "Bir hata oluştu!" + jqXHR.responseText,
                    type: 'error',
                    padding: '2em'
                });

            }

        });

    };


function companySelect() {
    var userName = $('#username').val();
    var password = $('#password').val();
    if (userName == '' || password == '') {
        ErrorMessage('Tüm alanları doldurunuz.');
    }
    var dataObject = JSON.stringify({
        'UserName': userName,
        'Password': password,
        'CompanyId': $('#company').val()
    });
    $.ajax({
        async: true,
        url: "/User/Login/",
        data: dataObject,
        contentType: "application/json",
        type: "POST",
        success: function (sonuc) {
            if (sonuc != null && sonuc != "") {
                window.location.href = "/Home/Index";
            }
            else {

                swal({
                    title: 'Hata!',
                    text: 'Hata',
                    type: 'error',
                    padding: '2em'
                });
            }

        }
        , error: function (jqXHR, exception) {
            console.log(jqXHR);
            console.log(exception);
            swal({
                title: 'Hata!',
                text: "Bir hata oluştu!" + jqXHR.responseText,
                type: 'error',
                padding: '2em'
            });

        }

    });
}
