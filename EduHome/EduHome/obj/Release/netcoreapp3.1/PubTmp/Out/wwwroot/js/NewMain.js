$(document).on("click", ".load-comments", function (e) {
    e.preventDefault();

    var nextPage = $(this).attr("data-nextpage");
    console.log(nextPage)
    var url = $(this).attr("href") + "?page=" + nextPage;

    console.log(url);
    fetch(url)
        .then(response => response.text())
        .then(data => {
            $(".comments").append(data)
        });

    var totalPage = +$(this).data("totalpage");
    nextPage = +nextPage + 1;

    if (nextPage > totalPage) {
        $(this).remove();
    }
    $(this).attr("data-nextpage", nextPage)
})