
    var connection = new signalR.HubConnectionBuilder().withUrl("/chat").build();
    $("#send").disabled = true;

    connection.on("ReceiveMessage", function (user, message) {
        var msg = message.replace(/&/g, "&").replace(/</g, "<").replace(/>/g, ">");
        var li = $("<li></li>").text(user + ": " + msg);
        li.addClass("list-group-item");
        $("#messagesList").append(li);
    });

    connection.start().then(function () {
        $("#send").disabled = false;
    }).catch(function (err) {
        return console.error(err.toString());
    });

    $("#send").on("click", function (event) {

        var user = $('label[for="user"]').text();
        var message = $("#message").val();
        

        Number.prototype.padLeft = function (base, chr) {
            var len = (String(base || 10).length - String(this).length) + 1;
            return len > 0 ? new Array(len).join(chr || '0') + this : this;
        }

        var date = new Date();
        var day = date.getDate();
        var month = date.getMonth() + 1;
        var year = date.getFullYear().padLeft(); 
        var hour = date.getHours().padLeft();     
        var minute = date.getMinutes().padLeft(); 
        var second = date.getSeconds().padLeft();

        var time = day + "/" + month.padLeft() + "/" + year + " " + hour + ':' + minute + ':' + second;

        connection.invoke("SendMessage", user, message, time).catch(function (err) {
            return console.error(err.toString());
        });

        connection.invoke("SaveMessage", user, message, time).catch(function (err) {
            return console.error(err.toString());
        });

        event.preventDefault();        
    });