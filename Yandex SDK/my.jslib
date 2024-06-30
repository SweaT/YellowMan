mergeInto(LibraryManager.library, {

  Hello: function () {
    window.alert("Hello, world!");
    console.log("Hello world!");
  },

  AuthExtern: function () {
    authication();
    myGameInstance.SendMessage('Yandex', 'SetName', player.getName());
    myGameInstance.SendMessage('Yandex', 'SetPhoto', player.getPhoto("medium"));
  },

  SaveExtern: function (date) {
    var dateString = UTF8ToString(date);
    var myobj = JSON.parse(dateString);
    player.setData(myobj);

  },

  LoadExtern: function () {
    player.getData().then(_date => {
      const myJSON = JSON.stringify(_date);
      myGameInstance.SendMessage('Progress', 'SetPlayerInfo', myJSON);
    })

  },

  Rate: function () {
    ysdk.feedback.canReview()
    .then(({ value, reason }) => {
      if (value) {
        ysdk.feedback.requestReview()
        .then(({ feedbackSent }) => {
          console.log(feedbackSent);
        })
      } else {
        console.log(reason)
      }
    });
  },

});   