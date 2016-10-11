var alreadyConnected = false;

function EnterNotification(form, signal, ids) {
	var hub = $.connection.WwwSurferNotificationHub;
	var timeOut;
	hub.client[signal] = function()
	{
		window.clearTimeout(timeOut);
		timeOut = window.setTimeout(function()
		{
			form.submit();
		}, 500);
	};

	if (alreadyConnected === true)
		hub.server.joinSignal(signal, ids);
	else {
		$.connection.hub.disconnected(function () {
			setTimeout(function () {
				$.connection.hub.start();
			}, 5000); // Restart connection after 5 seconds.
		});
		$.connection.hub.start()
			.done(function () {
				alreadyConnected = true;
				hub.server.joinSignal(signal, ids);
			});
	}
}


function ExecuteUrl(event, website) {
	event.preventDefault();
	var domElement = $(this);
	if (domElement.hasClass('disabledLink'))
		return;

	domElement.addClass('disabledLink');
	$.ajax({
		url: website,
		timeout: 50000,
		success: function (data, textStatus) {
			domElement.removeClass('disabledLink');
		},
		error: function (xhr, textStatus, errorThrown) {
			domElement.removeClass('disabledLink');
			alert("Ein Fehler ist aufgetreten: " + xhr.responseText);
		}
	});
}
