// ── Random Array Generator ────────────────────────────────
function fillRandom() {
    const count = Math.floor(Math.random() * 15) + 5;
    const nums  = Array.from({ length: count }, () => Math.floor(Math.random() * 999) + 1);
    const input = document.getElementById('InputNumbers');
    if (input) input.value = nums.join(', ');
}

// ── Benchmark Runner ──────────────────────────────────────
async function runBenchmark() {
    const size    = document.getElementById('benchSize').value;
    const results = document.getElementById('benchResults');
    const spinner = document.getElementById('spinner');
    const table   = document.getElementById('benchTable');
    const tbody   = document.getElementById('benchBody');

    results.classList.remove('hidden');
    spinner.classList.remove('hidden');
    table.classList.add('hidden');

    try {
        const res  = await fetch(`/Home/Benchmark?size=${size}`);
        const data = await res.json();

        const rows = [
            { name: 'QuickSort (Recursive)', ms: data.quickSortRecursive },
            { name: 'QuickSort (Iterative)', ms: data.quickSortIterative },
            { name: 'MergeSort',             ms: data.mergeSort          },
            { name: 'HeapSort',              ms: data.heapSort           },
            { name: 'Array.Sort (Built-in)', ms: data.builtInSort        },
        ];

        // Sort by speed for ranking
        const sorted = [...rows].sort((a, b) => a.ms - b.ms);
        const maxMs  = Math.max(...rows.map(r => r.ms));

        tbody.innerHTML = rows.map(row => {
            const rank    = sorted.findIndex(r => r.name === row.name) + 1;
            const barW    = maxMs > 0 ? Math.round((row.ms / maxMs) * 160) : 0;
            const medal   = rank === 1 ? '🥇' : rank === 2 ? '🥈' : rank === 3 ? '🥉' : `#${rank}`;
            return `<tr>
                <td>${row.name}</td>
                <td><span class="bar" style="width:${barW}px"></span>${row.ms.toFixed(4)} ms</td>
                <td>${medal}</td>
            </tr>`;
        }).join('');

        spinner.classList.add('hidden');
        table.classList.remove('hidden');

    } catch (err) {
        spinner.textContent = '❌ Error running benchmark. Please try again.';
        console.error(err);
    }
}
