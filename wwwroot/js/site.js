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

});