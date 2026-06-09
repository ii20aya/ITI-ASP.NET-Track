// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
window.addEventListener('scroll', () => {
    const journey = document.getElementById('scrollJourney');
    const paper = document.getElementById('journeyPaper');
    const folder = document.getElementById('folderEl');
    const rect = journey.getBoundingClientRect();
    const total = journey.offsetHeight - window.innerHeight;
    const progress = Math.max(0, Math.min(1, -rect.top / total));

    if (progress > 0.15) {
        // paper moves down and to the right into folder
        const t = (progress - 0.15) / 0.85;
        paper.style.transform = `translateY(${t * 280}px) scale(${1 - t * 0.35})`;
        paper.style.opacity = 1 - t * 0.4;
        folder.style.transform = `translateY(${t * -20}px)`;
        // open folder lid
        folder.querySelector('.folder-lid').style.transform =
            t < 0.5 ? `rotateX(${t * 2 * -45}deg)` : `rotateX(-45deg)`;
    }
});