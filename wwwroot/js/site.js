function FilterTransctions() {
    var form = $('#TransctionsFm');
    var url = "/FinTrans/FilterIndex";
    $.ajax({
        url: url,
        type: "POST",
        dataType: "html",
        data: form.serialize(),     
        success: function (data) {
            $("tbody").empty();
            $("tbody").append(data);
        },
        error: function (xhr, desc, err) {
            Swal.fire({
                type: 'error',
                title: 'خطاء...',
                text: "هنالك خطاء تاكد من صحة البيانات",
            })
        }
    });

}
function sectExecl(t) {
    $("#isexcel").val(t);
}
function FiltercontentIndex() {
    var form = $('#contentfm');
    $.ajax({
        url: form.attr('action'),
        type: "POST",
        dataType: "html",
        data: form.serialize(),     
        success: function (data) {
            document.getElementById("contentdiv").innerHTML = "";
            document.getElementById("contentdiv").innerHTML = data;
        },
        error: function (xhr, desc, err) {
            Swal.fire({
                type: 'error',
                title: 'خطاء...',
                text: "هنالك خطاء تاكد من صحة البيانات",
            })
        }
    });

}

function FilterCreteria() {
    var form = $('#evaluationfm');
    $.ajax({
        url: form.attr('action'),
        type: "POST",
        dataType: "html",
        data: form.serialize(),
        success: function (data) {
            document.getElementById("EvaluationDiv").innerHTML = "";
            document.getElementById("EvaluationDiv").innerHTML = data;
        },
        error: function (xhr, desc, err) {
            Swal.fire({
                type: 'error',
                title: 'خطاء...',
                text: "هنالك خطاء تاكد من صحة البيانات",
            })
        }
    });

}

function FilterlevelsIndex() {
    var form = $('#Levelsfm');
    $.ajax({
        url: form.attr('action'),
        type: "POST",
        dataType: "html",
        data: form.serialize(),
        success: function (data) {
            document.getElementById("levelsdiv").innerHTML = "";
            document.getElementById("levelsdiv").innerHTML = data;
        },
        error: function (xhr, desc, err) {
            Swal.fire({
                type: 'error',
                title: 'خطاء...',
                text: "هنالك خطاء تاكد من صحة البيانات",
            })
        }
    });

}
function filterteachers() {
    var fm = document.getElementById("filterteachers");
    var form = $('#filterteachers');    
    $.ajax({
        url: form.attr('action'),
        type: "POST",
        dataType: "html",
        data: form.serialize(),
              success: function (data) {
                  $("tbody").empty();
                  $("tbody").append( data);
    },
        error: function (xhr, desc, err) {
            Swal.fire({
                type: 'error',
                title: 'خطاء...',
                text: "هنالك خطاء تاكد من صحة البيانات",
            })
        }
    });

}

function filterFathers() {
    var form = $('#filterstudent');    
    $.ajax({
        url: form.attr('action'),
        type: "POST",
        dataType: "html",
        data: form.serialize(),
              success: function (data) {
                  $("tbody").empty();
                  $("tbody").append( data);
    },
        error: function (xhr, desc, err) {
            Swal.fire({
                type: 'error',
                title: 'خطاء...',
                text: "هنالك خطاء تاكد من صحة البيانات",
            })
        }
    });

}


function FilterTestsIndex() {
    var fm = document.getElementById("FilterTestsIndex");
    var form = $('#FilterTestsIndex');    
    $.ajax({
        url: "/Tests/"+form.attr('action'),
        type: "POST",
        dataType: "html",
        data: form.serialize(),
              success: function (data) {
                  document.getElementById("testsdiv").innerHTML = "";
                  document.getElementById("testsdiv").innerHTML = data;
    },
        error: function (xhr, desc, err) {
            Swal.fire({
                type: 'error',
                title: 'خطاء...',
                text: "هنالك خطاء تاكد من صحة البيانات",
            })
        }
    });

}

function FilterSubjects() {
    var fm = document.getElementById("subjectsfm");
    var form = $('#subjectsfm');
    $.ajax({
        url: form.attr('action'),
        type: "POST",
        dataType: "html",
        data: form.serialize(),
        success: function (data) {
            document.getElementById("subjectsdiv").innerHTML = "";
            document.getElementById("subjectsdiv").innerHTML = data;
        },
        error: function (xhr, desc, err) {
            Swal.fire({
                type: 'error',
                title: 'خطاء...',
                text: "هنالك خطاء تاكد من صحة البيانات",
            })
        }
    });

}

function FilterAccoladeIndeex() {
    var fm = document.getElementById("accolidsfm");
    var form = $('#accolidsfm');
    $.ajax({
        url: form.attr('action'),
        type: "POST",
        dataType: "html",
        data: form.serialize(),
        success: function (data) {
            document.getElementById("accoldediv").innerHTML = "";
            document.getElementById("accoldediv").innerHTML = data;
        },
        error: function (xhr, desc, err) {
            Swal.fire({
                type: 'error',
                title: 'خطاء...',
                text: "هنالك خطاء تاكد من صحة البيانات",
            })
        }
    });

}
function FilterPackages() {
    var fm = document.getElementById("pakcagesfm");
    var form = $('#pakcagesfm');
    $.ajax({
        url: form.attr('action'),
        type: "POST",
        dataType: "html",
        data: form.serialize(),
        success: function (data) {
            document.getElementById("packagesdiv").innerHTML = "";
            document.getElementById("packagesdiv").innerHTML = data;
        },
        error: function (xhr, desc, err) {
            Swal.fire({
                type: 'error',
                title: 'خطاء...',
                text: "هنالك خطاء تاكد من صحة البيانات",
            })
        }
    });

}

function FilterAccolades() {
    var fm = document.getElementById("filteraccolades");
    var form = $('#filteraccolades');
    //var data = new FormData(fm);
    //var url = $(fm).attr("action");
    $.ajax({
        url: form.attr('action'),
        type: "POST",
        dataType: "html",
        data: form.serialize(),
        //processData: false,
        //contentType: "application/json; charset=utf-8",
        success: function (data) {
            document.getElementById("contentId").innerHTML = "";
            document.getElementById("contentId").innerHTML =data;
           



        },
        error: function (xhr, desc, err) {
            Swal.fire({
                type: 'error',
                title: 'خطاء...',
                text: "هنالك خطاء تاكد من صحة البيانات",
            })
        }
    });

}
function appendfeatures() {
    var fm = document.getElementById("featuresdiv");
    var item = '<div class="row"> <div class="col-md-6" >' +

        '<div class="form-group"><label  class="control-label">المعيار</label> <input name="Feature" id="Feature" required class="form-control" /> </div> </div >' +
        '<div class="col-md-6"> <div class="form-group">  <label  class="control-label">القيمة</label><input name="FeatureValue" id="FeatureValue" required class="form-control" /></div></div></div > ';
    fm.insertAdjacentHTML('beforeend', item);




}
$(".postmonth").on("submit", function (event) {
    event.preventDefault();
    var fm = new FormData(this);
    var url = $(this).attr("action");
    const inputs = document.querySelectorAll('input[name="Feature"]');
    const vals = document.querySelectorAll('input[name="FeatureValue"]');
    const itemsList = [];
    inputs.forEach((inputs, index) => {
        const item = {
           
            Feature: inputs.value,            
            FeatureValue: vals[index].value
        };
        itemsList.push(item);
    });
    //fm.append('feature', JSON.stringify(itemsList));
    fm.append('items', JSON.stringify(itemsList));
    $.ajax({
        url: url,
        type: "POST",
        dataType: "JSON",
        data: fm,
        processData: false,
        contentType: false,
        success: function (data) {
            if (data.state == 1) {
                Swal.fire({
                    title: 'نجـــاح',
                    type: 'success',
                    text: data.message,
                    timer: 1500
                })
            }
            else {
                Swal.fire({
                    type: 'error',
                    title: 'خطاء...',
                    text: data.message,
                })
            }

        },
        error: function (xhr, desc, err) {
            Swal.fire({
                type: 'error',
                title: 'خطاء...',
                text: "هنالك خطاء تاكد من صحة البيانات",
            })
        }
    });

});


$("#cityCreate").on("submit", function (event) {
    event.preventDefault();
    var data = new FormData(this);
    var url = $(this).attr("action");
    $.ajax({
        url: url,
        type: "POST",
        dataType: "JSON",
        data: new FormData(this),
        processData: false,
        contentType: false,
        success: function (data) {
            if (data.state == 1) {
                Swal.fire({
                    title: 'نجـــاح',
                    type: 'success',
                    text: data.message,
                    timer: 1500
                })
            }
            else {
                Swal.fire({
                    type: 'error',
                    title: 'خطاء...',
                    text: data.message,
                })
            }

        },
        error: function (xhr, desc, err) {
            Swal.fire({
                type: 'error',
                title: 'خطاء...',
                text: "هنالك خطاء تاكد من صحة البيانات",
            })
        }
    });

});



$(".submitfm").on("submit", function (event) {
    event.preventDefault();
    var data = new FormData(this);
    var url = $(this).attr("action");
    $.ajax({
        url: url,
        type: "POST",
        dataType: "JSON",
        data: new FormData(this),
        processData: false,
        contentType: false,
        success: function (data) {
            if (data.state == 1) {

           

                Swal.fire({
                    title: 'نجـــاح',
                    html: data.message,
                    icon: "success",
                    type: "success",

                    confirmButtonText: "Ok",
                }).then((result) => {
                    if (result.value) {

                        window.location.reload();
                    }
                });
            }
            else if (data.state == 2) {
                Swal.fire({
                    title: 'نجـــاح',
                    html: data.message,
                    icon: "success",
                    type: "success",

                    confirmButtonText: "Ok",
                }).then((result) => {
                    if (result) {
                        window.location.href = data.url;
                    }
                });
            }
            else  {
                Swal.fire({
                    type: 'error',
                    title: 'خطاء...',
                    text: data.message,
                })
            }

        },
        error: function (xhr, desc, err) {
            Swal.fire({
                type: 'error',
                title: 'خطاء...',
                text: "هنالك خطاء تاكد من صحة البيانات",
            })
        }
    });

});
$(".submitrm").on("submit", function (event) {
    event.preventDefault();
    var data = new FormData(this);
    var url = $(this).attr("action");
    console.log("item");
    Swal.fire({
        title: "هل انت متاكد من عملية الحذف؟",
        type: "warning",
        icon: "warning",
        showCancelButton: true,
        confirmButtonColor: "#3085d6",
        cancelButtonColor: "#d33",
        cancelButtonText: "لا",
        confirmButtonText: "نعم",

    }).then((result) => {
        if (result.value) {

    $.ajax({
        url: url,
        type: "POST",
        dataType: "JSON",
        data: new FormData(this),
        processData: false,
        contentType: false,
        success: function (data) {
            if (data.state == 1) {
                Swal.fire({
                    title: 'نجـــاح',
                    html: data.message,
                    icon: "success",
                    type: "success",

                    confirmButtonText: "Ok",
                }).then((result) => {
                    if (result.value) {

                        window.location.reload();
                    }
                });
            }
            else if (data.state == 2) {
                Swal.fire({
                    title: 'نجـــاح',
                    html: data.message,
                    icon: "success",
                    type: "success",

                    confirmButtonText: "Ok",
                }).then((result) => {
                    if (result) {
                        window.location.href = data.url;
                    }
                });
            }
            else {
                Swal.fire({
                    type: 'error',
                    title: 'خطاء...',
                    text: data.message,
                })
            }

        },
        error: function (xhr, desc, err) {
            Swal.fire({
                type: 'error',
                title: 'خطاء...',
                text: "هنالك خطاء تاكد من صحة البيانات",
            })
        }
    });
        } 
    });
});




function AcceptTeacher(id) {
    const swalWithBootstrapButtons = Swal.mixin({
        customClass: {
            confirmButton: "btn btn-success m-1",
            cancelButton: "btn btn-danger m-1"
        },
        buttonsStyling: false
    });
    swalWithBootstrapButtons.fire({
        title: "هل انت متاكد من قبول المعلم؟",
        //text: "You won't be able to revert this!",
        icon: "warning",
        type: "warning",
        showCancelButton: true,
        
        cancelButtonText: "لا",
        confirmButtonText: "نعم",
        reverseButtons: false
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: "/Teachers/AcceptTeacher?Id=" + id,
                type: "POST",
                dataType: "JSON",
                data: { Id: id },
                processData: false,
                contentType: false,
                success: function (data) {
                    if (data.state == 1) {
                        Swal.fire({
                            title: 'نجـــاح',
                            html: data.message,
                            icon: "success",
                            type: "success",

                            confirmButtonText: "Ok",
                        }).then((result) => {
                            if (result) {

                                window.location.reload();
                            }
                        });
                    }
                    else {
                        Swal.fire({
                            type: 'error',
                            title: 'خطاء...',
                            text: data.message,
                        })
                    }

                },
                error: function (xhr, desc, err) {
                    Swal.fire({
                        type: 'error',
                        title: 'خطاء...',
                        text: "هنالك خطاء تاكد من صحة البيانات",
                    })
                }
            });
        }
    });

}

function onSubmitClick() {

    Swal.fire({
        title: "هل انت متاكد من عملية الحذف؟",
        type: "warning",
        icon: "warning",
        showCancelButton: true,
        confirmButtonColor: "#3085d6",
        cancelButtonColor: "#d33",
        cancelButtonText: "لا",
        confirmButtonText: "نعم",

    }).then((result) => {
        if (result.value) {
            console.log("true");
            return true;
        } else {
            console.log("false");
            return false;
        }
    });
}
function deleteFile(id) {
    Swal.fire({
        title: "هل انت متاكد من عملية الحذف؟",
        type: "warning",
        icon: "warning",
        showCancelButton: true,
        confirmButtonColor: "#3085d6",
        cancelButtonColor: "#d33",
        cancelButtonText: "لا",
        confirmButtonText: "نعم",

    }).then((result) => {
        if (result.value) {
            $.ajax({
                url: "/ControlPanel/DeleteImage/" + id,
                type: "POST",
                dataType: "JSON",
                data: { Id: id },
                processData: false,
                contentType: false,
                success: function (data) {
                    if (data.state == 1) {
                        Swal.fire({
                            title: 'نجـــاح',
                            html: data.message,
                            icon: "success",
                            type: "success",
                            confirmButtonText: "Ok",
                        }).then((result) => {
                            if (result) {
                                window.location.reload();
                            }
                        });
                    }
                    else {
                        Swal.fire({
                            type: 'error',
                            title: 'خطاء...',
                            text: data.message,
                        })
                    }

                },
                error: function (xhr, desc, err) {
                    Swal.fire({
                        type: 'error',
                        title: 'خطاء...',
                        text: "هنالك خطاء تاكد من صحة البيانات",
                    })
                }
            });
        }
    });

}

function DeleteFeature(id) {
    Swal.fire({
        title: "هل انت متاكد من عملية الحذف؟",
        type: "warning",
        icon: "warning",
        showCancelButton: true,
        confirmButtonColor: "#3085d6",
        cancelButtonColor: "#d33",
        cancelButtonText: "لا",
        confirmButtonText: "نعم",

    }).then((result) => {
        if (result.value) {
            $.ajax({
                url: "/ControlPanel/DeleteFeature/" + id,
                type: "POST",
                dataType: "JSON",
                data: { Id: id },
                processData: false,
                contentType: false,
                success: function (data) {
                    if (data.state == 1) {
                        Swal.fire({
                            title: 'نجـــاح',
                            html: data.message,
                            icon: "success",
                            type: "success",
                            confirmButtonText: "Ok",
                        }).then((result) => {
                            if (result) {
                                window.location.reload();
                            }
                        });
                    }
                    else {
                        Swal.fire({
                            type: 'error',
                            title: 'خطاء...',
                            text: data.message,
                        })
                    }

                },
                error: function (xhr, desc, err) {
                    Swal.fire({
                        type: 'error',
                        title: 'خطاء...',
                        text: "هنالك خطاء تاكد من صحة البيانات",
                    })
                }
            });
        }
    });

}
function removemonthcretrea(id) {
    Swal.fire({
        title: "هل انت متاكد من عملية الحذف؟",
        type: "warning",
        icon: "warning",
        showCancelButton: true,
        confirmButtonColor: "#3085d6",
        cancelButtonColor: "#d33",
        cancelButtonText: "لا",
        confirmButtonText: "نعم",

    }).then((result) => {
        if (result.value) {
            $.ajax({
                url: "/MonthTeachers/DeleteCretirea/" + id,
                type: "POST",
                dataType: "JSON",
                data: { Id: id },
                processData: false,
                contentType: false,
                success: function (data) {
                    if (data.state == 1) {
                        Swal.fire({
                            title: 'نجـــاح',
                            html: data.message,
                            icon: "success",
                            type: "success",
                            confirmButtonText: "Ok",
                        }).then((result) => {
                            if (result) {
                                window.location.reload();
                            }
                        });
                    }
                    else {
                        Swal.fire({
                            type: 'error',
                            title: 'خطاء...',
                            text: data.message,
                        })
                    }

                },
                error: function (xhr, desc, err) {
                    Swal.fire({
                        type: 'error',
                        title: 'خطاء...',
                        text: "هنالك خطاء تاكد من صحة البيانات",
                    })
                }
            });
        }
    });

}
function removeMonthteacher(id) {
    Swal.fire({
        title: "هل انت متاكد من عملية الحذف؟",
        type: "warning",
        icon: "warning",
        showCancelButton: true,
        confirmButtonColor: "#3085d6",
        cancelButtonColor: "#d33",
        cancelButtonText: "لا",
        confirmButtonText: "نعم",

    }).then((result) => {
        if (result.value) {
            $.ajax({
                url: "/MonthTeachers/Delete/" + id,
                type: "POST",
                dataType: "JSON",
                data: { Id: id },
                processData: false,
                contentType: false,
                success: function (data) {
                    if (data.state == 1) {
                        Swal.fire({
                            title: 'نجـــاح',
                            html: data.message,
                            icon: "success",
                            type: "success",
                            confirmButtonText: "Ok",
                        }).then((result) => {
                            if (result) {
                                window.location.reload();
                            }
                        });
                    }
                    else {
                        Swal.fire({
                            type: 'error',
                            title: 'خطاء...',
                            text: data.message,
                        })
                    }

                },
                error: function (xhr, desc, err) {
                    Swal.fire({
                        type: 'error',
                        title: 'خطاء...',
                        text: "هنالك خطاء تاكد من صحة البيانات",
                    })
                }
            });
        }
    });

}

function DeleteContent(id) {
    Swal.fire({
        title: "هل انت متاكد من عملية الحذف؟",
        type: "warning",
        icon: "warning",
        showCancelButton: true,
        confirmButtonColor: "#3085d6",
        cancelButtonColor: "#d33",
        cancelButtonText: "لا",
        confirmButtonText: "نعم",

    }).then((result) => {
        if (result.value) {
            $.ajax({
                url: "/ControlPanel/DeleteContent/" + id,
                type: "POST",
                dataType: "JSON",
                data: { Id: id },
                processData: false,
                contentType: false,
                success: function (data) {
                    if (data.state == 1) {
                        Swal.fire({
                            title: 'نجـــاح',
                            html: data.message,
                            icon: "success",
                            type: "success",
                            confirmButtonText: "Ok",
                        }).then((result) => {
                            if (result) {
                                window.location.href = "/ControlPanel/Index";
                            }
                        });
                    }
                    else {
                        Swal.fire({
                            type: 'error',
                            title: 'خطاء...',
                            text: data.message,
                        })
                    }

                },
                error: function (xhr, desc, err) {
                    Swal.fire({
                        type: 'error',
                        title: 'خطاء...',
                        text: "هنالك خطاء تاكد من صحة البيانات",
                    })
                }
            });
        }
    });

}
function DeleteAcolade(id){
    Swal.fire({
        title: "هل انت متاكد من عملية الحذف؟",
        type: "warning",
        icon: "warning",
        showCancelButton: true,
        confirmButtonColor: "#3085d6",
        cancelButtonColor: "#d33",
        cancelButtonText: "لا",
        confirmButtonText: "نعم",

    }).then((result) => {
        if (result.value) {
            $.ajax({
                url: "/Accolade/Delete/"+id,
                type: "POST",
                dataType: "JSON",
                data: { Id: id },
                processData: false,
                contentType: false,
                success: function (data) {
                    if (data.state == 1) {
                        Swal.fire({
                            title: 'نجـــاح',
                            html: data.message,
                            icon: "success",
                            type: "success",
                            confirmButtonText: "Ok",
                        }).then((result) => {
                            if (result) {
                                window.location.reload();
                            }
                        });
                    }
                    else {
                        Swal.fire({
                            type: 'error',
                            title: 'خطاء...',
                            text: data.message,
                        })
                    }

                },
                error: function (xhr, desc, err) {
                    Swal.fire({
                        type: 'error',
                        title: 'خطاء...',
                        text: "هنالك خطاء تاكد من صحة البيانات",
                    })
                }
            });
        }
    });

}

function RejectTeacher(id) {
    const swalWithBootstrapButtons = Swal.mixin({
        customClass: {
            confirmButton: "btn btn-success m-1",
            cancelButton: "btn btn-danger m-1"
        },
        buttonsStyling: false
    });
    swalWithBootstrapButtons.fire({
        title: "هل انت متاكد من رفض المعلم؟",
        //text: "You won't be able to revert this!",
        icon: "warning",
        type: "warning",
        showCancelButton: true,

        cancelButtonText: "لا",
        confirmButtonText: "نعم",
        reverseButtons: false
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: "/Teachers/RejectTeacher?Id=" + id,
                type: "POST",
                dataType: "JSON",
                data: { Id: id },
                processData: false,
                contentType: false,
                success: function (data) {
                    if (data.state == 1) {
                        Swal.fire({
                            title: 'نجـــاح',
                            html: data.message,
                            icon: "success",
                            type: "success",

                            confirmButtonText: "Ok",
                        }).then((result) => {
                            if (result) {

                                window.location.reload();
                            }
                        });
                    }
                    else {
                        Swal.fire({
                            type: 'error',
                            title: 'خطاء...',
                            text: data.message,
                        })
                    }

                },
                error: function (xhr, desc, err) {
                    Swal.fire({
                        type: 'error',
                        title: 'خطاء...',
                        text: "هنالك خطاء تاكد من صحة البيانات",
                    })
                }
            });
        
    }
    });
}
$(".submitreset").on("submit", function (event) {
    event.preventDefault();
    var data = new FormData(this);
    var url = $(this).attr("action");
    $.ajax({
        url: url,
        type: "POST",
        dataType: "JSON",
        data: new FormData(this),
        processData: false,
        contentType: false,
        success: function (data) {
            if (data.state == 1) {
                Swal.fire({
                    title: 'نجـــاح',
                    html: data.message,
                    icon: "success",
                    type: "success",
                    confirmButtonText: "Ok",
                }).then((result) => {
                    if (result) {
                        $("#message").val(""); 
                    }
                });
            }           
            else {
                Swal.fire({
                    type: 'error',
                    title: 'خطاء...',
                    text: data.message,
                })
            }
        },
        error: function (xhr, desc, err) {
            Swal.fire({
                type: 'error',
                title: 'خطاء...',
                text: "هنالك خطاء تاكد من صحة البيانات",
            })
        }
    });

}

// Enhanced Category Management Functions
// =====================================

// Filter categories in real-time
function filterCategoriesLive() {
    const searchInput = document.getElementById('searchInput');
    const sortSelect = document.getElementById('sortSelect');

    if (!searchInput) return;

    const searchTerm = searchInput.value.toLowerCase().trim();
    const sortValue = sortSelect ? sortSelect.value : 'name-asc';

    // Get all category items (both table rows and cards)
    const tableRows = document.querySelectorAll('#categoriesTable tbody tr');
    const cardElements = document.querySelectorAll('.category-card');

    let visibleCount = 0;

    // Filter table rows
    tableRows.forEach(row => {
        const name = row.getAttribute('data-name')?.toLowerCase() || '';
        const enname = row.getAttribute('data-enname')?.toLowerCase() || '';
        const isVisible = name.includes(searchTerm) || enname.includes(searchTerm) || searchTerm === '';

        row.style.display = isVisible ? '' : 'none';
        if (isVisible) visibleCount++;
    });

    // Filter card elements
    cardElements.forEach(card => {
        const name = card.getAttribute('data-name')?.toLowerCase() || '';
        const enname = card.getAttribute('data-enname')?.toLowerCase() || '';
        const isVisible = name.includes(searchTerm) || enname.includes(searchTerm) || searchTerm === '';

        card.style.display = isVisible ? '' : 'none';
    });

    // Show/hide no results message
    const noResults = document.getElementById('noResults');
    if (noResults) {
        if (visibleCount === 0 && searchTerm !== '') {
            noResults.style.display = 'block';
            const tableView = document.getElementById('tableView-content');
            const cardView = document.getElementById('cardView-content');
            if (tableView) tableView.style.display = 'none';
            if (cardView) cardView.style.display = 'none';
        } else {
            noResults.style.display = 'none';
            // Restore current view
            const currentView = document.querySelector('input[name="viewMode"]:checked')?.id || 'tableView';
            toggleCategoryView(currentView === 'tableView' ? 'table' : 'card');
        }
    }
}

// Toggle between table and card view for categories
function toggleCategoryView(viewType) {
    const tableView = document.getElementById('tableView-content');
    const cardView = document.getElementById('cardView-content');

    if (!tableView || !cardView) return;

    if (viewType === 'table') {
        tableView.style.display = 'block';
        cardView.style.display = 'none';
    } else {
        tableView.style.display = 'none';
        cardView.style.display = 'block';
    }
}

// Sort categories
function sortCategoriesData() {
    const sortSelect = document.getElementById('sortSelect');
    if (!sortSelect) return;

    const sortValue = sortSelect.value;
    const [field, direction] = sortValue.split('-');

    // Get all category data
    const tableRows = Array.from(document.querySelectorAll('#categoriesTable tbody tr'));
    const cardElements = Array.from(document.querySelectorAll('.category-card'));

    // Create combined array for sorting
    const categories = tableRows.map((row, index) => ({
        name: row.getAttribute('data-name') || '',
        enname: row.getAttribute('data-enname') || '',
        tableRow: row,
        cardElement: cardElements[index]
    }));

    // Sort the array
    categories.sort((a, b) => {
        let aValue = field === 'name' ? a.name : a.enname;
        let bValue = field === 'name' ? b.name : b.enname;

        if (direction === 'asc') {
            return aValue.localeCompare(bValue);
        } else {
            return bValue.localeCompare(aValue);
        }
    });

    // Reorder elements in DOM
    const tableBody = document.querySelector('#categoriesTable tbody');
    const cardContainer = document.getElementById('cardView-content');

    if (tableBody) {
        categories.forEach(category => {
            if (category.tableRow) {
                tableBody.appendChild(category.tableRow);
            }
        });
    }

    if (cardContainer) {
        categories.forEach(category => {
            if (category.cardElement) {
                cardContainer.appendChild(category.cardElement);
            }
        });
    }
}

// Enhanced form validation
function validateCategoryForm(formSelector) {
    const form = document.querySelector(formSelector);
    if (!form) return true;

    let isValid = true;
    const requiredFields = form.querySelectorAll('input[required]');

    requiredFields.forEach(field => {
        const value = field.value.trim();
        const fieldName = field.getAttribute('name');

        // Remove previous validation classes
        field.classList.remove('is-invalid', 'is-valid');

        if (!value) {
            field.classList.add('is-invalid');
            isValid = false;
        } else {
            // Additional validation based on field type
            if (fieldName === 'IconLink' && value) {
                // Validate URL format
                const urlPattern = /^(https?:\/\/)?([\da-z\.-]+)\.([a-z\.]{2,6})([\/\w \.-]*)*\/?$/;
                if (!urlPattern.test(value)) {
                    field.classList.add('is-invalid');
                    isValid = false;
                } else {
                    field.classList.add('is-valid');
                }
            } else {
                field.classList.add('is-valid');
            }
        }
    });

    return isValid;
}

// Auto-save draft functionality
function enableAutoSave(formSelector) {
    const form = document.querySelector(formSelector);
    if (!form) return;

    const formId = form.getAttribute('id') || 'categoryForm';
    const inputs = form.querySelectorAll('input[type="text"], textarea');

    // Load saved draft
    inputs.forEach(input => {
        const savedValue = localStorage.getItem(`${formId}_${input.name}`);
        if (savedValue && !input.value) {
            input.value = savedValue;
        }
    });

    // Save on input
    inputs.forEach(input => {
        input.addEventListener('input', function() {
            localStorage.setItem(`${formId}_${input.name}`, this.value);
        });
    });

    // Clear draft on successful submit
    form.addEventListener('submit', function() {
        inputs.forEach(input => {
            localStorage.removeItem(`${formId}_${input.name}`);
        });
    });
}

// Enhanced image preview with validation
function previewImageWithValidation(input, previewElementId, maxSize = 5 * 1024 * 1024) {
    const preview = document.getElementById(previewElementId);
    if (!preview || !input.files || !input.files[0]) return;

    const file = input.files[0];

    // Validate file size
    if (file.size > maxSize) {
        Swal.fire({
            icon: 'error',
            title: 'حجم الملف كبير جداً',
            text: `حجم الملف يجب أن يكون أقل من ${maxSize / (1024 * 1024)} ميجابايت`
        });
        input.value = '';
        return;
    }

    // Validate file type
    const allowedTypes = ['image/jpeg', 'image/png', 'image/gif', 'image/webp', 'image/svg+xml'];
    if (!allowedTypes.includes(file.type)) {
        Swal.fire({
            icon: 'error',
            title: 'نوع الملف غير مدعوم',
            text: 'يرجى اختيار صورة بصيغة JPG, PNG, GIF, WebP, أو SVG'
        });
        input.value = '';
        return;
    }

    const reader = new FileReader();
    reader.onload = function(e) {
        preview.innerHTML = `<img src="${e.target.result}" alt="Preview" style="width: 100%; height: 100%; object-fit: cover; border-radius: 10px;">`;
    };
    reader.readAsDataURL(file);
}

// Bulk operations for categories
function initializeBulkOperations() {
    const selectAllCheckbox = document.getElementById('selectAll');
    const itemCheckboxes = document.querySelectorAll('.item-checkbox');
    const bulkActions = document.getElementById('bulkActions');

    if (!selectAllCheckbox || !itemCheckboxes.length) return;

    // Select all functionality
    selectAllCheckbox.addEventListener('change', function() {
        itemCheckboxes.forEach(checkbox => {
            checkbox.checked = this.checked;
        });
        toggleBulkActions();
    });

    // Individual checkbox change
    itemCheckboxes.forEach(checkbox => {
        checkbox.addEventListener('change', function() {
            const checkedCount = document.querySelectorAll('.item-checkbox:checked').length;
            selectAllCheckbox.checked = checkedCount === itemCheckboxes.length;
            selectAllCheckbox.indeterminate = checkedCount > 0 && checkedCount < itemCheckboxes.length;
            toggleBulkActions();
        });
    });

    function toggleBulkActions() {
        const checkedCount = document.querySelectorAll('.item-checkbox:checked').length;
        if (bulkActions) {
            bulkActions.style.display = checkedCount > 0 ? 'block' : 'none';
        }
    }
}

// Initialize all category management features
document.addEventListener('DOMContentLoaded', function() {
    // Initialize search functionality
    const searchInput = document.getElementById('searchInput');
    if (searchInput) {
        searchInput.addEventListener('input', filterCategoriesLive);
    }

    // Initialize sort functionality
    const sortSelect = document.getElementById('sortSelect');
    if (sortSelect) {
        sortSelect.addEventListener('change', sortCategoriesData);
    }

    // Initialize view toggle
    const viewRadios = document.querySelectorAll('input[name="viewMode"]');
    viewRadios.forEach(radio => {
        radio.addEventListener('change', function() {
            const viewType = this.id === 'tableView' ? 'table' : 'card';
            toggleCategoryView(viewType);
        });
    });

    // Initialize auto-save for forms
    enableAutoSave('.needs-validation');

    // Initialize bulk operations
    initializeBulkOperations();

    // Add smooth animations
    const cards = document.querySelectorAll('.card, .category-card');
    cards.forEach(card => {
        card.style.transition = 'all 0.3s ease-in-out';
    });
}););