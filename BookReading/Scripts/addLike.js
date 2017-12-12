$('.like-btn').click(function () {
    var reviewId = $(this).data('review');
    var $this = $(this).children('.like');
    $.post({
        'url': '/Review/IncrementAndGetLikes',
        'data': { reviewId: reviewId },
        'success': function (Like) {
            $this.text(Like);
        },
        'error': function (_, error) {
            alert('error: ' + error);
        }
    });
});
