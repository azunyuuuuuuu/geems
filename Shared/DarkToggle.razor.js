export function themeSetLightMode() {
    // Whenever the user explicitly chooses dark mode
    localStorage.theme = 'dark'
    refreshState();
    console.log("set dark mode");
}

export function themeSetDarkMode() {
    // Whenever the user explicitly chooses light mode
    localStorage.theme = 'light'
    refreshState();
    console.log("set light mode");
}

export function themeSetOsMode() {
    // Whenever the user explicitly chooses to respect the OS preference
    localStorage.removeItem('theme')
    refreshState();
    console.log("set os theme mode");
}


function refreshState() {
    if (localStorage.theme === 'dark' || (!('theme' in localStorage) && window.matchMedia('(prefers-color-scheme: dark)').matches)) {
        document.documentElement.classList.add('dark')
    } else {
        document.documentElement.classList.remove('dark')
    }
}
