using UnityEngine;

public class CoinsFactory : MonoBehaviour
{
        [SerializeField] private GameObject _coinPrefab;

        [SerializeField] private float _minFrequency;
        [SerializeField] private float _maxFrequency;

        [SerializeField] private Transform _spawnPoint;

        [SerializeField] private float _spawnPointOffset;

        private Vector3 _spawnPointPosition;

        private float _timer;
        private float _nextTimer;

        private void Start()
        {
            _nextTimer = Random.Range(_minFrequency, _maxFrequency);
            _spawnPointPosition = _spawnPoint.position;

            Create();
        }

        private void Update()
        {
            _timer += Time.deltaTime;

            if (_timer >= _nextTimer)
            {
                Create();

                _timer = 0;
                _nextTimer = Random.Range(_minFrequency, _maxFrequency);
            }
        }


        public void Create()
        {
            GameObject enemy = Instantiate(_coinPrefab, transform);

            TeleportEnemy(enemy);
        }

        private void TeleportEnemy(GameObject enemy)
        {
            Vector2 teleportPosition = new Vector2(
                _spawnPointPosition.x,
                _spawnPointPosition.y + Random.Range(-_spawnPointOffset, _spawnPointOffset));

            if (Physics2D.OverlapCircle(teleportPosition, 1f) == false)
            {
                enemy.transform.position = teleportPosition;
            }
            else
            {
                TeleportEnemy(enemy);
            }
        }
}
