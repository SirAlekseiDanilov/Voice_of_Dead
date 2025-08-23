using UnityEngine;
using UnityEngine.Events; // передача события на обработку на стороне

namespace VoD {

    public class PatrolController : AIController {
        private Patch m_Patch;
        private int patchIndex;

        /// <summary>
        /// Событие (блок команд) завершения пути (врагом).
        /// </summary>
        [SerializeField] private UnityEvent OnEndPath;
        public void SetPatch(Patch newPath) {
            m_Patch = newPath;
            patchIndex = 0;
            SetPatrolBehaviour(m_Patch[patchIndex]);
        }

        protected override void GetNewPoint() {
            patchIndex += 1;
            if (m_Patch.Lenghth > patchIndex) {
                SetPatrolBehaviour(m_Patch[patchIndex]);
            }
            else {
                // Вызываю событие завершения пути.
                OnEndPath.Invoke();
                // Харакири врага.
                Destroy(gameObject);
            }
        }
    }
}