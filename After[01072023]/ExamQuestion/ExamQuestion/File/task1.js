var datatable;
var data = [];
var modal;
var Taskmodal
var Isvalid;
var row;
var DetailIndex;
var obj;
var Time;
$(document).ready(function () {
    modal = $('#modalId');
    Taskmodal = $('#modalId1')
    $(modal).on('hide.bs.modal', () => {
        $(modal).find('.input').val("")

    })
    $(Taskmodal).on('hide.bs.modal', () => {
        $(Taskmodal).find('.input').val("")

    })
    datatable = $("#Table").DataTable({
        data: data,
        columns: [
            {
                title: "",
                data: null,
                defaultContent: "",
                class: "dt-control"
            },
            {
                title: "Name",
                data: "Name",
                class: "Name"
            },
            {
                title: "DOB",
                data: "DOB",
                class: "DOB"
            },
            {
                title: "Email",
                data: "Email",
                class: "Email"
            },
            {
                title: "Contact Number",
                data: "ContactNumber",
                class: "ContactNumber"
            },
            {
                title: "Gender",
                data: "Gender",
                class: "Gender"
            },
            {
                title: "Action",
                data: null,
                defaultContent: `<button type="button" class="btn btn-primary btn-sm" data-bs-toggle="modal" data-bs-target="#modalId1" id="AddTask">
                Add Task
              </button>
              <button type="button" class="btn btn-info btn-sm" id="Edit">Edit</button>
              <button type="button" class="btn btn-danger btn-sm" id="Delete">Delete</button>`
            }
        ]
    })
    $('#AddUser').on('click', function () {
        $("#Update").css('display', 'none')
        $("#Save").css('display', 'block')
        $('span').html('')
    })

    $("#Save").on('click', function () {
        var Name = $("#Name").val();
        var DOB = $("#DOB").val();
        var Email = $("#Email").val();
        var contactNumber = $("#Number").val();
        var filter = /^((\+[1-9]{1,4}[ \-]*)|(\([0-9]{2,3}\)[ \-]*)|([0-9]{2,4})[ \-]*)*?[0-9]{3,4}?[ \-]*[0-9]{3,4}?$/;
        var regex = /[^\s@]+@[^\s@]+\.[^\s@]+/;
        var validName = /^[A-Z a-z]+$/;
        var gender = $('input[name="btn"]:checked').val()
        Isvalid = true;
        if (Name == '') {
            $("#NameInput").html("Please Enter Name")
            $("#NameInput").css("color", "red")
            Isvalid = false
        } else if (!validName.test(Name)) {
            $("#NameInput").html("Please Enter Valid Name")
            $("#NameInput").css("color", "red")
            Isvalid = false
        }
        if (DOB == '') {
            $("#DateInput").html("Please Enter Date")
            $("#DateInput").css("color", "red")
            Isvalid = false
        }
        if (Email == '') {
            $("#EmailInput").html("Please Enter Email")
            $("#EmailInput").css("color", "red")
            Isvalid = false

        } else if (!regex.test(Email)) {
            $("#EmailInput").html("Please Enter Valid Email")
            $("#EmailInput").css("color", "red")
            Isvalid = false
        }
        if (contactNumber == '') {
            $("#NumberInput").html("Please Enter Contact Number")
            $("#NumberInput").css("color", "red")
            Isvalid = false

        } else if (!filter.test(contactNumber)) {
            $("#NumberInput").html("Please Enter Valid Contact Number")
            $("#NumberInput").css("color", "red")
            Isvalid = false
        }
        if (!gender) {
            $("#GenderInput").html("Please Enter Gender")
            $("#GenderInput").css("color", "red")
            Isvalid = false
        }
        else if (Isvalid) {
            obj = {
                "Name": Name,
                "DOB": DOB,
                "Email": Email,
                "ContactNumber": contactNumber,
                "Gender": gender,
                "Details": []
            }
            data.push(obj);
            datatable.row.add(obj).draw();

            $(modal).modal('hide')
        }

    })

    $("#Table").on('click', '#Delete', function () {
        datatable.row($(this).parents('tr')).remove().draw()
    })

    $("#Table").on('click', '#Edit', function () {
        $(modal).modal('show')
        $("#Update").css('display', 'block')
        $("#Save").css('display', 'none')
        var namevalue = $(this).parents('tr').find('td:eq(1)').html();
        var DOBvalue = $(this).parents('tr').find('td:eq(2)').html();
        var emailvalue = $(this).parents('tr').find('td:eq(3)').html();
        var contactNumbervalue = $(this).parents('tr').find('td:eq(4)').html();
        var gendervalue = $(this).parents('tr').find('td:eq(5)').html();
        row = $(this).parents('tr').index();
        $("#Name").val(namevalue);
        $("#DOB").val(DOBvalue);
        $("#Email").val(emailvalue);
        $("#Number").val(contactNumbervalue);
        $(`input[value = ${gendervalue}]`).prop("checked", true)

    })

    $("#Update").on('click', function () {
        var Name = $("#Name").val();
        var DOB = $("#DOB").val();
        var Email = $("#Email").val();
        var contactNumber = $("#Number").val();
        var filter = /^((\+[1-9]{1,4}[ \-]*)|(\([0-9]{2,3}\)[ \-]*)|([0-9]{2,4})[ \-]*)*?[0-9]{3,4}?[ \-]*[0-9]{3,4}?$/;
        var regex = /[^\s@]+@[^\s@]+\.[^\s@]+/;
        var validName = /^[A-Z a-z]+$/;
        var gender2 = $('input[name="btn"]:checked').val();
        console.log(gender2);
        Isvalid = true;
        if (Name == '') {
            $("#NameInput").html("Please Enter Name")
            $("#NameInput").css("color", "red")
            Isvalid = false
        } else if (!validName.test(Name)) {
            $("#NameInput").html("Please Enter Valid Name")
            $("#NameInput").css("color", "red")
            Isvalid = false
        }
        if (DOB == '') {
            $("#DateInput").html("Please Enter Date")
            $("#DateInput").css("color", "red")
            Isvalid = false
        }
        if (Email == '') {
            $("#EmailInput").html("Please Enter Email")
            $("#EmailInput").css("color", "red")
            Isvalid = false

        } else if (!regex.test(Email)) {
            $("#EmailInput").html("Please Enter Valid Email")
            $("#EmailInput").css("color", "red")
            Isvalid = false
        }
        if (contactNumber == '') {
            $("#NumberInput").html("Please Enter Contact Number")
            $("#NumberInput").css("color", "red")
            Isvalid = false

        } else if (!filter.test(contactNumber)) {
            $("#NumberInput").html("Please Enter Valid Contact Number")
            $("#NumberInput").css("color", "red")
            Isvalid = false
        }
        if (!gender2) {
            $("#GenderInput").html("Please Enter Gender")
            $("#GenderInput").css("color", "red")
            Isvalid = false
        }
        else if (Isvalid) {
            var Editobj = {
                "Name": Name,
                "DOB": DOB,
                "Email": Email,
                "ContactNumber": contactNumber,
                "Gender": gender2,
                "Details": []
            }
            data[row] = Editobj
            console.log(data);
            datatable.clear().draw();
            datatable.rows.add(data).draw();

            $(modal).modal('hide')
        }
    })
    $("#Table").on('click', '#AddTask', function () {
       
            $("#UpdateTask").css('display', 'none')
            $("#SaveTask").css('display', 'block')
       
        $('span').html('')
        DetailIndex = $(this).parents('tr').index();
        console.log(DetailIndex);
    })
    $("#SaveTask").on('click', function () {
        var Title = $("#Task").val();
        var Description = $("#Description").val();
        var DUD = $("#DUD").val();
        var DateTime = new Date(DUD);
     Time = DateTime.getTime();
        console.log(DUD);
        Isvalid = true;
        if (Title == '') {
            $("#TaskInput").html("Please Enter Name")
            $("#TaskInput").css("color", "red")
            Isvalid = false
        } if (Description == '') {
            $("#DescriptionInput").html("Please Enter Description")
            $("#DescriptionInput").css("color", "red")
            Isvalid = false
        }
        if (DUD == '') {
            $("#DatetimeInput").html("Please Enter Date & Time")
            $("#DatetimeInput").css("color", "red")
            Isvalid = false
        }
        else if (Isvalid) {
            var Detailsobj = {
                "Title": Title,
                "Description": Description,
                "DUD": DUD
            }
            var object = data[DetailIndex]
            object.Details.push(Detailsobj)
            $(Taskmodal).modal('hide')
       }
    })

    $('table tbody').on('click', '.dt-control', function () {
        var tr = $(this).closest('tr');
        var row2 = datatable.row(tr);
        if (row2.child.isShown()) {
            // This row is already open - close it
            row2.child.hide();
            tr.removeClass('shown');
        } else {
            // Open this row
            row2.child(format(data[DetailIndex].Details)).show();
            tr.addClass('shown');
        }
    });
});
function format(d) {
    var str = `<div class="container"><table id="Table2">
        <thead>
        <tr>
        <th>Title</th>
        <th>Description</th>
        <th>Due Date</th>
        <th>Action</th>
        </tr>
        </thead><tbody>`
    d.forEach(element => {
        str += `<tr><td>${element.Title}</td> <td>${element.Description}</td> <td>${element.DUD}</td> <td><button type="button" class="btn btn-info btn-sm" id="EditTask">Edit</button>
        <button type="button" class="btn btn-danger btn-sm" id="DeleteTask">Delete</button></td></tr>`
    })
    str += `</tbody></table></div>`
    return (str);
}

// function setInterval(() => {
    
// }, interval);

$(document).ready(function(){
    
    $("#Table2").on('click', '#EditTask', function () {
        $(Taskmodal).modal('show')
        $("#UpdateTask").css('display', 'none')
        $("#SaveTask").css('display', 'block')
    })
    
    $("#Table2").on('click', '#DeleteTask', function () {
        $(this).parent.parent.remove();
    })

})