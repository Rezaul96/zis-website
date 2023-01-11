let wow = new WOW(
    {
        boxClass: 'wow',      // animated element css class (default is wow)
        animateClass: 'animated', // animation css class (default is animated)
        offset: 0,          // distance to the element when triggering the animation (default is 0)
        mobile: true,       // trigger animations on mobile devices (default is true)
        live: true,       // act on asynchronously loaded content (default is true)
        callback: function (box) {
            // the callback is fired every time an animation is started
            // the argument that is passed in is the DOM node being animated
        },
        scrollContainer: null,    // optional scroll container selector, otherwise use window,
        resetAnimation: true,     // reset animation on end (default is true)
    }
);
wow.init();


document.querySelector(".goTop").addEventListener("click", () => {
    document.querySelector("html").scrollTop = 0;
});

const setUpMenu = () => {

    let navItems = document.querySelectorAll('.nav-item');
    let mobileNav = document.querySelector('.mobile-nav');

    if (window.innerWidth <= 992) {
        document.querySelector("header").classList.add("fixed");
        document.querySelector("header").classList.add("left-0");
        document.querySelector("header").classList.add("right-0");
        document.querySelector("header").classList.add("z-30");
        document.querySelector("header").classList.add("bg-white");
        // document.querySelector("#mobile-gap").style.height = document.querySelector('header').offsetHeight + "px";

        navItems.forEach(item => {
            mobileNav.appendChild(item);
        });

    } else {
        document.querySelector("header").classList.remove("fixed");
        document.querySelector("header").classList.remove("left-0");
        document.querySelector("header").classList.remove("right-0");
        document.querySelector("header").classList.add("z-30");
        document.querySelector("header").classList.add("bg-white");
    }
}


window.addEventListener('resize', () => {
    setUpMenu()
})


setUpMenu()