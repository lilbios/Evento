
        // Modal Function

    let siteBody = document.querySelector("body");
    let mainWindow = document.querySelector(".mainWindow");
    let popUpBtn = document.querySelectorAll(".popUpBtn");
    let popUp = document.querySelectorAll(".popUp");
    let modalWindow = document.querySelector(".modalWindow");
    let closeModal = document.querySelectorAll(".closeModal");
    let notificationBell = document.querySelector(".notificationBell");
    let notificationBar = document.querySelector(".notificationBar");



        function openLayer() {
        mainWindow.classList.toggle("mainWindow--inactive");
            siteBody.classList.toggle("disableScrolling");
            modalWindow.classList.toggle("modalWindow--inactive");
        }

        function closeLayer() {
        mainWindow.classList.toggle("mainWindow--inactive");
            siteBody.classList.toggle("disableScrolling");
            modalWindow.classList.add("modalWindow--inactive");
        }

        popUpBtn.forEach(e => {
        e.addEventListener("click", () => {
            openLayer();
            let targetPopUp = document.getElementById(e.dataset.targetPopup);
            targetPopUp.classList.remove("popUp--inactive");
        });
        });

        notificationBell.addEventListener("click", () => {
        openLayer();
            notificationBar.classList.remove("notificationBar--inactive");
        });

        closeModal.forEach(e => {
        e.addEventListener("click", () => {
            closeLayer();
            popUp.forEach(popUp => {
                popUp.classList.add("popUp--inactive");
            });
            notificationBar.classList.add("notificationBar--inactive");


        });
        });

        // Single Page Functionality
        let darkModeSet = "false";
        let singlePageLinks = document.querySelectorAll(".singlePageLink");
        let contentSinglePage = document.querySelectorAll(".content--singlePage");
        singlePageLinks.forEach(e => {
        e.addEventListener("click", () => {
            contentSinglePage.forEach(page => {
                page.classList.remove("content--singlePage--active");
            });
            let targetPageId = "content--" + e.dataset.targetRef;
            let targetPage = document.getElementById(targetPageId);
            targetPage.classList.add("content--singlePage--active");
            sizeProjectTable();
            if (darkModeSet == "true") {
                singlePageLinks.forEach(s => {
                    s.classList.remove('navigation__item--active--dark');
                });
                e.classList.toggle('navigation__item--active--dark');
            } else {
                singlePageLinks.forEach(s => {
                    s.classList.remove('navigation__item--active--dark');
                });
            }
        });
        });

        singlePageLinks[0].click();

